using System;
using System.IO;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    public class FileInfoWrapper : IFileInfo
    {
        FileInfo _fi;

        public FileInfoWrapper(FileInfo fi)
        {
            _fi = fi;
        }


        public string FullName => _fi.FullName;
        public string Name => _fi.Name;
        public long Length => _fi.Length;
        public DateTime LastWriteTimeUtc => _fi.LastWriteTimeUtc;

        public string Extension => _fi.Extension;
    }
}
