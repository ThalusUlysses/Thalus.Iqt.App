using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Thalus.Iqt.Core
{

    public class IqtExcludesDTO : IIqtExcludesDTO
    {
        public IEnumerable<string> Files { get; set; }

        public IEnumerable<string> FileNamePatterns { get; set; }

        public IEnumerable<string> FileEndings { get; set; }


        public bool UseDirectoryTimeStamp { get; set; }

        public IEnumerable<string> Direcories { get; set; }

        public IEnumerable<string> DirectoryNamePatterns { get; set; }
    }
}
