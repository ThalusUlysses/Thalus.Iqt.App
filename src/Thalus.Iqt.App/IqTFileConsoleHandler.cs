using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Thalus.Contracts;
using Thalus.Iqt.Core;

namespace Thalus.Iqt.App
{
    class IqTFileConsoleHandler
    {
        Action<string> _logMe;
        int _exitCode = 0;
        IResult _result;
        bool _verbose;

        public IqTFileConsoleHandler() : this(null)
        {

        }

        public IqTFileConsoleHandler(Action<string> log)
        {
            _logMe = log;
        }

        public int ExitCode => _exitCode;
        public IResult ExitResult => _result;

        public int Process(string[] args)
        {
            EnsureVerboseOutput(args);
            args = EnsureDebugModeIfRequested(args);
            Run(args);

            if (_result != null)
            {
                SafeLog(_result.GetText().Invariant, _result);
            }

            return _exitCode;
        }

        private void Run(string[] args)
        {
            Parser.Default.ParseArguments<CreateOptions, CompareOptions, ExitCodes>(args)
             .WithParsed<CreateOptions>(ProcessCreateOptions)
             .WithParsed<CompareOptions>(ProcessComareOptions)
             .WithParsed<ExitCodes>(ProcessExitCodes)
             .WithNotParsed(ProcessErrors);
        }

        private void EnsureVerboseOutput(string[] args)
        {
            _verbose = args.Any(i => i.Equals("--verbose", StringComparison.InvariantCultureIgnoreCase));
        }

        private static string[] EnsureDebugModeIfRequested(string[] args)
        {
#if DEBUG

            if (args.Any(i => i.Equals("--debug")))
            {
                args = args.Where(i => !i.Equals("--debug")).ToArray();

                if (!Debugger.IsAttached)
                {
                    Debugger.Launch();
                }
            }
#endif

            return args;
        }

        private void SafeLog(string text, object data = null)
        {
            if (_logMe == null)
            {
                return;
            }

            _logMe.Invoke(text);

            if (data != null && _verbose)
            {
                _logMe.Invoke(JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }

        private void ProcessExitCodes(ExitCodes c)
        {

        }

        private IqtExcludesDTO CreateExcludesFrom(CreateOptions args)
        {
            return new IqtExcludesDTO
            {
                DirectoryNamePatterns = args.ExcludeDirectoryNamePatterns.ToArray(),
                Direcories = args.ExcludeDirectories.ToArray(),
                FileNamePatterns = args.ExcludeFileNamePattern.ToArray(),
                FileEndings = args.ExcludeFileEndings.ToArray(),
                Files = args.ExcludeFiles.ToArray(),
                UseDirectoryTimeStamp = args.UseDirectoryTimeStamp
            };
        }

        private void ProcessErrors(IEnumerable<Error> list)
        {
            var o = list.First();

            if (o.Tag == ErrorType.HelpRequestedError || o.Tag == ErrorType.HelpVerbRequestedError)
            {
                SetResultAndExitCode(Result.Ok());
                return;
            }
            SetResultAndExitCode(Result.Fail(500, "Parsing of arguments failed", data: JsonConvert.SerializeObject(o, Formatting.Indented)));
        }

        private void ProcessCreateOptions(CreateOptions options)
        {
            try
            {
                IPoorMansIoC ioc = new IqtIoc();

                var rCreator = ioc.Get<IIqtIdentityCreator>().ThrowIfException();
                var creator = rCreator.ResultSet;

                var excludes = CreateExcludesFrom(options);

                var current = creator.CreateFrom(excludes, options.Directories.ToArray());

                IqtOutFileAccess access = new IqtOutFileAccess();

                var set = new IqtIdentitySetDTO { Excludes = excludes, Identities = current };

                var result = access.Write(set, options.OutFile, options.Force);

                if (result.Success)
                {
                    result = Result.Ok(invariant: $"Created IQT file sucessfully at: {options.OutFile}", data: result.Data);
                }

                SetResultAndExitCode(result);
            }
            catch (Exception ex)
            {
                SetResultAndExitCode(Result.Exception(ex));

            }
        }

        private void ProcessComareOptions(CompareOptions options)
        {
            try
            {
                IqtOutFileAccess a = new IqtOutFileAccess();

                var result = a.Read(options.ReferenceFile);

                if (!result.Success)
                {
                    SetResultAndExitCode(result);
                    return;
                }

                IPoorMansIoC ioc = new IqtIoc();

                var rCreator = ioc.Get<IIqtIdentityCreator>().ThrowIfException();
                var rCompare = ioc.Get<IIqtIdentityCompare>().ThrowIfException();

                IIqtIdentityCreator creator = rCreator.ResultSet;
                IIqtIdentityCompare comparer = rCompare.ResultSet;

                var reference = result.GetData<IqtIdentitySetDTO>();

                var current = creator.CreateFrom(reference.Excludes, options.Directories.ToArray());

                var comparerResult = comparer.CompareIdentities(reference.Identities, current);

                var writeResult = a.Write(comparerResult.GetData<IqtIdentityResultSetDTO>(), options.OutFile, options.Force);

                IResult overallResult = writeResult.Success ?
                    Result.Ok(code: comparerResult.Code, invariant: $"IQT comparison complete. Find result ad: {options.OutFile}", data: comparerResult.Data) :
                    Result.Fail(code: 403, $"Failed to wirte result to: {options.OutFile}", data: comparerResult.Data);

                SetResultAndExitCode(overallResult);
            }
            catch (Exception ex)
            {
                SetResultAndExitCode(Result.Exception(ex));
            }
        }

        private void SetResultAndExitCode(IResult r)
        {
            if (_result == null)
            {
                _result = r;
            }

            if (_exitCode == 0 && r.Code == 203)
            {
                _exitCode = r.Code;
            }

            if (_exitCode == 0 && r.Code < 200 || r.Code >= 300)
            {
                _exitCode = r.Code;
            }
        }
    }
}
