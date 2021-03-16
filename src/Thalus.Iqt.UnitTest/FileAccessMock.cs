using System;
using System.IO;
using System.Text;
using Thalus.Contracts;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.UnitTest
{
    class FileAccessMock : IIoAccess
    {
        DateTime _time = DateTime.UtcNow;
        bool _writeReadFails;

        public FileAccessMock(bool writeReadFails)
        {
            _writeReadFails = writeReadFails;

        }

        public string[] GetDirectories(string dirName)
        {
            return new string[0];

        }

        public IDirectoryInfo GetDirectoryInfoFor(string fileName)
        {
            DirectoryInfo fi = new DirectoryInfo(fileName);

            return new DirectoryInfoMock { FullName = fileName, Name = fi.Name, CreationTimeUtc = _time, LastWriteTimeUtc = _time, Extension = fi.Extension, Length = 400 };
        }

        public string[] GetFileNames(string directory)
        {
            return new[] { "c:/klaus/myfile.org" };
        }

        public IFileInfo GetFileInfo(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            return new DirectoryInfoMock { FullName = fileName, Name = fi.Name, CreationTimeUtc = _time, LastWriteTimeUtc = _time, Extension = fi.Extension, Length = 400 };

        }

        public IFileVersionInfo GetVersionInfoOf(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            return new DirectoryInfoMock { FullName = fileName, Name = fi.Name, CreationTimeUtc = _time, LastWriteTimeUtc = _time, Extension = fi.Extension, Length = 400 };
        }

        public IResult ReadAllText(string fileName, Encoding enc = null)
        {
            return _writeReadFails ? Result.Fail(404) : Result.Ok();
        }

        public IResult WriteAllText(string text, string fileName, bool overwrite = false, Encoding enc = null)
        {
            return _writeReadFails ? Result.Fail(404) : Result.Ok();

        }
    }
}