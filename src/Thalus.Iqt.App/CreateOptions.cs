using CommandLine;
using System.Collections.Generic;

namespace Thalus.Iqt.App
{
    [Verb("create", HelpText = "Creates an Installation Qualification Test file from existing folders")]
    class CreateOptions
    {
        [Option('o',"output",HelpText = "Installation Qualification Test reference output file *.json")]
        public string OutFile { get; set; }

        [Option('f', "force", HelpText = "Enables overwriting existing reference files *.json")]
        public bool Force { get; set; }


        [Option('d', "directory", HelpText = "Directories that are associated with the IQT reference file. List of directories to include")]
        public IEnumerable<string> Directories { get; set; }

        [Option("exclude-files", HelpText = "Exclude specific list of files from IQT creation with full qualified name")]
        public IEnumerable<string> ExcludeFiles { get; set; }
        
        [Option("exclude-file-endings", HelpText ="Exclude a list of files with specific file endings")]
        public IEnumerable<string> ExcludeFileEndings { get; set; }

        [Option("exclude-file-regex", HelpText ="Exclude files by list of regular expressions")]
        public IEnumerable<string> ExcludeFileNamePattern { get; set; }

        [Option("exclude-directories", HelpText ="Exclude list of directoreis by full qualified name")]
        public IEnumerable<string> ExcludeDirectories { get; set; }  

        [Option("exclude-directory regex", HelpText = "Exclude list of directoreis by regular expression")]
        public IEnumerable<string> ExcludeDirectoryNamePatterns { get; set; }

        [Option("use-directory-creationdate", HelpText = "Include createion time stamp utc to directory identity")]
        public bool UseDirectoryTimeStamp { get; set; }

        [Option('v', "verbose", HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }
}
