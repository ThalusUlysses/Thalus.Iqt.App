using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Thalus.Contracts;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    public class FileAccess : IoAccess
    {
        public IFileVersionInfo GetVersionInfoOf(string fileName)
        {
            return new FileVersionInfoWrapper(FileVersionInfo.GetVersionInfo(fileName));
        }

        public string[] GetFileNames(string directory)
        {
            return Directory.GetFiles(directory);
        }

        public string[] GetDirectories(string dirName)
        {
            return Directory.GetDirectories(dirName);
        }

        public IFileInfo GetFileInfo(string fileName)
        {
            return new FileInfoWrapper(new FileInfo(fileName));
        }

        public IDirectoryInfo GetDirectoryInfoFor(string fileName)
        {
            return new DirectoryInfoWrapper(new DirectoryInfo(fileName));
        }

        public IResult WriteAllText(string text, string fileName, bool overwrite = false, Encoding enc = null)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                EnsureDirectoryExists(fi);

                if (File.Exists(fileName))
                {
                    if (!overwrite)
                    {
                        return Result.Fail(403, $"File {fileName} already exists and overwrite is false");
                    }
                    else
                    {
                        File.Delete(fileName);
                    }
                }

                enc = EnsureEncoding(enc);

                File.WriteAllText(fileName, text, enc);

                return Result.Ok(invariant: $"Write all text to {fileName}", data: text);
            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Writing of {fileName} failed fatally");
            }
        }

        public IResult ReadAllText(string fileName, Encoding enc = null)
        {
            try
            {
                enc = EnsureEncoding(enc);
                if (!File.Exists(fileName))
                {
                    return Result.Fail(404, $"File {fileName} does not exist");
                }

                var text = File.ReadAllText(fileName, enc);

                return Result.Ok(invariant: $"Read all text from {fileName}", data: text);
            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Reading of {fileName} failed fatally");
            }
        }

        Encoding EnsureEncoding(Encoding enc)
        {
            return enc ?? Encoding.Default;
        }

        void EnsureDirectoryExists(FileInfo path)
        {
            if (!path.Directory.Exists)
            {
                path.Directory.Create();
            }
        }
    }
}
