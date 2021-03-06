﻿using System.Globalization;
using Thalus.Iqt.Core.Contracts;
using Thalus.Iqt.Core.Contracts.DTO;

namespace Thalus.Iqt.Core
{
    class IqtIdentityFactory : IIqtIdentityFactory
    {
        IIqtHashCreator _hash;

        public IqtIdentityFactory(IIqtHashCreator hash)
        {
            _hash = hash;
        }

        public IIqtIdentity Create(IFileInfo fi, IFileVersionInfo fvi)
        {
            var qualifiedName = CreateQualifiedNameFrom(fi, fvi);
            var hash = _hash.CreateHash(qualifiedName);
            return new IqtIdentityDTO
            {
                Name = fi.Name,
                FullName = fi.FullName,
                Hash = hash,
                QualifiedName = qualifiedName,
            };
        }

        public IIqtIdentity Create(IDirectoryInfo di, bool includeDirectoryCreationTime)
        {
            string qualifiedName = includeDirectoryCreationTime ? $"{di.FullName}_{di.CreationTimeUtc.ToString(CultureInfo.InvariantCulture)}" : $"{di.FullName}";

            var hash = _hash.CreateHash(qualifiedName);

            return new IqtIdentityDTO
            {
                Name = di.Name,
                FullName = di.FullName,
                Hash = hash,
                QualifiedName = qualifiedName,
            };
        }

        private string CreateQualifiedNameFrom(IFileInfo fi, IFileVersionInfo k)
        {
            string qualifiedName = $"{fi.FullName}_{fi.LastWriteTimeUtc.ToString(CultureInfo.InvariantCulture)}_{fi.Length}";
            if (k.ProductName != null)
            {
                qualifiedName = $"{k.FileName}_{k.ProductName}_{k.ProductVersion}_{k.FileVersion}_{fi.Length}";
            }

            return qualifiedName;
        }



    }
}
