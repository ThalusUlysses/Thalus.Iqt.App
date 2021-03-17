using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{

    class IqtIdentityCreator : IIqtIdentityCreator
    {
        IIoAccess _access;
        IIqtIdentityFactory _iqtFactory;

        public IqtIdentityCreator(IIoAccess access, IIqtIdentityFactory fact)
        {
            _access = access;
            _iqtFactory = fact;
        }

        public IIqtIdentity[] CreateFrom(IIqtExcludes excludes = null, params string[] directories)
        {
            List<IIqtIdentity> identities = new List<IIqtIdentity>();

            RecursiveDirectoryWalker(directories, identities, excludes);

            return identities.ToArray();
        }

        bool ExcludeFile(IFileInfo filename, IIqtExcludes ex)
        {
            if (ex?.FileEndings != null && ex.FileEndings.Any(i => i.Equals(filename.Extension, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }

            if (ex?.FileNamePatterns != null)
            {
                foreach (var pattern in ex.FileNamePatterns)
                {
                    if (Regex.Match(filename.FullName, pattern).Success)
                    {
                        return true;
                    }
                }
            }

            if (ex?.Files != null && ex.Files.Any(i => i.Equals(filename.FullName, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }

            return false;
        }

        bool ExcludeDirectory(IDirectoryInfo filename, IIqtExcludes ex)
        {

            if (ex?.DirectoryNamePatterns != null)
            {
                foreach (var pattern in ex.DirectoryNamePatterns)
                {
                    if (Regex.Match(filename.FullName, pattern).Success)
                    {
                        return true;
                    }
                }
            }

            if (ex?.Direcories != null && ex.Direcories.Any(i => i.Equals(filename.FullName, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }

            return false;
        }

        private void RecursiveDirectoryWalker(string[] dirNames, List<IIqtIdentity> identities, IIqtExcludes ex)
        {
            foreach (var dirName in dirNames)
            {
                InspectFolder(dirName, identities, ex);
                var files = _access.GetFileNames(dirName);
                InspectFiles(files, identities, ex);

                RecursiveDirectoryWalker(_access.GetDirectories(dirName), identities, ex);
            }
        }

        private void InspectFiles(string[] files, List<IIqtIdentity> identities, IIqtExcludes ex)
        {
            foreach (var item in files)
            {
                var fi = _access.GetFileInfo(item);
                var fvi = _access.GetVersionInfoOf(item);

                var exclude = ExcludeFile(fi, ex);
                var identity = _iqtFactory.Create(fi, fvi);
                identity.Excluded = exclude;

                identities.Add(identity);
            }
        }

        private void InspectFolder(string folder, List<IIqtIdentity> identities, IIqtExcludes ex)
        {
            var di = _access.GetDirectoryInfoFor(folder);

            var exclude = ExcludeDirectory(di, ex);
            var useDir = ex != null ? ex.UseDirectoryTimeStamp : false;
            var identity = _iqtFactory.Create(di, useDir);
            identity.Excluded = exclude;

            identities.Add(identity);
        }
    }
}
