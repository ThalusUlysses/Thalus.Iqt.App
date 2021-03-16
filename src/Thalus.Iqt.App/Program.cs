using System;

namespace Thalus.Iqt.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IqTFileConsoleHandler hndlr = new IqTFileConsoleHandler(LogMeToConsole);

            Environment.ExitCode = hndlr.Process(args);

            Console.WriteLine($"Iqt exited with exitcode:{hndlr.ExitCode}");
        }

        static void LogMeToConsole(string st)
        {
            Console.WriteLine(st);
        }
    }
}
