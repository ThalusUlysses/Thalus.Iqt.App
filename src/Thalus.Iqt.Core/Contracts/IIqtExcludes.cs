using System.Collections.Generic;

namespace Thalus.Iqt.Core.Contracts
{
    public interface IIqtExcludes
    {
        IEnumerable<string> Direcories { get; set; }
        IEnumerable<string> DirectoryNamePatterns { get; set; }
        IEnumerable<string> FileEndings { get; set; }
        IEnumerable<string> FileNamePatterns { get; set; }
        IEnumerable<string> Files { get; set; }
        bool UseDirectoryTimeStamp { get; set; }
    }
}