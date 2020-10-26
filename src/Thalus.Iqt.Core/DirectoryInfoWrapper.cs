using System;
using System.IO;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    public class DirectoryInfoWrapper : IDirectoryInfo
    {
        DirectoryInfo _di;

        public DirectoryInfoWrapper(DirectoryInfo di)
        {
            _di = di;
        }

        public string FullName => _di.FullName;
        public string Name => _di.Name;
        public DateTime CreationTimeUtc => _di.CreationTimeUtc;
    }
}
