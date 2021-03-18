using CommandLine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Thalus.Contracts;

namespace Thalus.Iqt.App
{
    [Verb("create", HelpText = "Creates an Installation Qualification Test file from existing folders")]
    class CreateOptions
    {
        [Option('o', "output", HelpText = "Installation Qualification Test reference output file *.json")]
        public string OutFile { get; set; }

        [Option('f', "force", HelpText = "Enables overwriting existing reference files *.json")]
        public bool Force { get; set; }


        [Option('d', "directory", HelpText = "Directories that are associated with the IQT reference file. List of directories to include")]
        public IEnumerable<string> Directories { get; set; }

        [Option("exclude-files", HelpText = "Exclude specific list of files from IQT creation with full qualified name")]
        public IEnumerable<string> ExcludeFiles { get; set; }

        [Option("exclude-file-endings", HelpText = "Exclude a list of files with specific file endings")]
        public IEnumerable<string> ExcludeFileEndings { get; set; }

        [Option("exclude-file-regex", HelpText = "Exclude files by list of regular expressions")]
        public IEnumerable<string> ExcludeFileNamePattern { get; set; }

        [Option("exclude-directories", HelpText = "Exclude list of directoreis by full qualified name")]
        public IEnumerable<string> ExcludeDirectories { get; set; }

        [Option("exclude-directory regex", HelpText = "Exclude list of directoreis by regular expression")]
        public IEnumerable<string> ExcludeDirectoryNamePatterns { get; set; }

        [Option("use-directory-creationdate", HelpText = "Include createion time stamp utc to directory identity")]
        public bool UseDirectoryTimeStamp { get; set; }

        [Option('v', "verbose", HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        public IResult IsDataConsistent()
        {
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
