using System.Runtime.InteropServices;
using System.Threading;

namespace Thalus.Iqt.Core
{

    public class IqtExcludesDTO
    {
        public string[] Files { get; set; }

        public string[] FileNamePatterns { get; set; }

        public string[] FileEndings { get; set; }


        public bool UseDirectoryTimeStamp { get; set; }

        public string[] Direcories { get; set; }

        public string[] DirectoryNamePatterns { get; set; }
    }
}
