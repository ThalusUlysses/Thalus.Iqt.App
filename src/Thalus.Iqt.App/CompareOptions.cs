using CommandLine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Thalus.Contracts;

namespace Thalus.Iqt.App
{
    [Verb("compare", HelpText = "Compares an Installation Qualification Test file with the current installation (IQT)")]
    class CompareOptions
    {
        [Option('r', "reference", HelpText = "Installation qualification Test reference file *.json")]
        public string ReferenceFile { get; set; }

        [Option('d', "directory", HelpText = "Directories that are associated with the IQT reference file. List of directories to test")]
        public IEnumerable<string> Directories { get; set; }

        [Option('o', "output", HelpText = "Installation Qualification Test result output file *.json")]
        public string OutFile { get; set; }

        [Option('f', "force", HelpText = "Enables overwriting existin result files *.json")]
        public bool Force { get; set; }

        [Option('v', "verbose", HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        public IResult IsDataConsistent()
        {
            if (string.IsNullOrEmpty(ReferenceFile))
            {
                return Result.Fail(400, $"Parameter --reference not set. Parameter is mandatory but is null or empty");
            }

            if (!File.Exists(ReferenceFile))
            {
                return Result.Fail(404, $"Parameter --reference is set but file {ReferenceFile} does not exist");
            }

            if (string.IsNullOrEmpty(OutFile))
            {
                return Result.Fail(400, $"Parameter --output not set. Parameter is mandatory but is null or empty");
            }

            if (File.Exists(OutFile) && !Force)
            {
                return Result.Fail(400, $"Parameter --output is set but file already exists. Either delet the file or use parameter --force");
            }

            if (Directories == null)
            {
                return Result.Fail(400, $"Parameter --driectory not set. Parameter is mandatory but is null");
            }

            if (!Directories.Any())
            {
                return Result.Fail(400, $"Parameter --driectory not set. Parameter is mandatory but list ist empty");
            }

            foreach (var item in Directories)
            {
                if (!Directory.Exists(item))
                {
                    return Result.Fail(404, $"Parameter --directory is see, but directory {item} does not exits");
                }
            }

            return Result.Ok();
        }
    }
}
