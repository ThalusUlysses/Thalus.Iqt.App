using CommandLine;

namespace Thalus.Iqt.App
{
    [Verb("exitcodes", HelpText = "List of exit codes")]
    public class ExitCodes
    {

        [Option("CreationFailed_400", HelpText = "Creation of Iqt file failed")]
        public int CreationOfIQTFileFailed { get; set; } = 400;

        [Option("CompareEqual_402", HelpText = "Comparison of Iqt file was successful but reference file and current state are not equal")]
        public int ComparisonOfIQTSuccessfulButAreNotEqual { get; set; } = 402;


        [Option("CompareFailed_401", HelpText = "Comparison of Iqt file failed")]
        public int ComparisonOfIQTFailed { get; set; } = 401;

        [Option("Fatal_500", HelpText = "Fatal error occured")]
        public int Fatal { get; set; } = 500;

    }
}
