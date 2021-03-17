using System.Collections.Generic;

namespace Thalus.Iqt.Core.Contracts.DTO
{

    public class IqtExcludesDTO : IIqtExcludes
    {
        public IEnumerable<string> Files { get; set; }

        public IEnumerable<string> FileNamePatterns { get; set; }

        public IEnumerable<string> FileEndings { get; set; }


        public bool UseDirectoryTimeStamp { get; set; }

        public IEnumerable<string> Direcories { get; set; }

        public IEnumerable<string> DirectoryNamePatterns { get; set; }
    }
}
