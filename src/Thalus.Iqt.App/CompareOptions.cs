using CommandLine;
using System.Collections.Generic;

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
    }
}
