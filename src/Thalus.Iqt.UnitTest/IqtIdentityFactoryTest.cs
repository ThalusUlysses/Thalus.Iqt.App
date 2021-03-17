using NUnit.Framework;
using System;
using System.Security.Cryptography;
using Thalus.Iqt.Core;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class IqtIdentityFactoryTest
    {
        public static IIqtHashCreator[] HashCreators { get; set; } = new[]
        {
           CreatHashes(SHA1.Create())
        };

        static IIqtHashCreator CreatHashes(HashAlgorithm a)
        {
            IPoorMansIoC ioC = new IqtIoc();
            ioC.Register<HashAlgorithm>(() => { return a; });

            var fResult = ioC.Get<IIqtHashCreator>().ThrowIfException();

            return fResult.ResultSet;
        }


        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("HashCreators")]

        public void CreateDefaultDirectoryIdentitiesTest(IIqtHashCreator c)
        {
            IPoorMansIoC ioC = new IqtIoc();
            ioC.Register<IIqtHashCreator>(() => { return c; });

            var fResult = ioC.Get<IIqtIdentityFactory>().ThrowIfException();

            IIqtIdentityFactory fact = fResult.ResultSet;

            DirectoryInfoMock m = new DirectoryInfoMock
            {
                FullName = "c:/klaus",
                Name = "klaus",
                CreationTimeUtc = DateTime.UtcNow
            };

            var k = fact.Create(m, false);

            Assert.IsFalse(k.Excluded);
            Assert.AreEqual(m.FullName, k.FullName);
            Assert.AreEqual(m.Name, k.Name);
            Assert.NotNull(k.Hash);
            Assert.NotNull(k.QualifiedName, $"{m.FullName}");
        }


        [Test(Author = "ThalusUlysses", Description = "Checks")]

        [TestCaseSource("HashCreators")]
        public void CreateDirectoryIdentitiesTest(IIqtHashCreator c)
        {
            IPoorMansIoC ioC = new IqtIoc();
            ioC.Register<IIqtHashCreator>(() => { return c; });

            var fResult = ioC.Get<IIqtIdentityFactory>().ThrowIfException();

            IIqtIdentityFactory fact = fResult.ResultSet;

            DirectoryInfoMock m = new DirectoryInfoMock
            {
                FullName = "c:/klaus",
                Name = "klaus",
                CreationTimeUtc = DateTime.UtcNow
            };

            var k = fact.Create(m, true);

            Assert.IsFalse(k.Excluded);
            Assert.AreEqual(m.FullName, k.FullName);
            Assert.AreEqual(m.Name, k.Name);
            Assert.NotNull(k.Hash);
            Assert.NotNull(k.QualifiedName, $"{m.FullName}_{m.CreationTimeUtc}");
        }


        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("HashCreators")]
        public void CreateDefaultFileIdentitiesTest(IIqtHashCreator c)
        {
            IPoorMansIoC ioC = new IqtIoc();
            ioC.Register<IIqtHashCreator>(() => { return c; });

            var fResult = ioC.Get<IIqtIdentityFactory>().ThrowIfException();

            IIqtIdentityFactory fact = fResult.ResultSet;

            DirectoryInfoMock m = new DirectoryInfoMock
            {
                FullName = "c:/klaus.org",
                Name = "klaus.org",
                Length = 400,
                CreationTimeUtc = DateTime.UtcNow
            };

            var k = fact.Create(m, m);

            Assert.IsFalse(k.Excluded);
            Assert.AreEqual(m.FullName, k.FullName);
            Assert.AreEqual(m.Name, k.Name);
            Assert.NotNull(k.Hash);
            Assert.NotNull(k.QualifiedName, $"{m.FullName}_{m.LastWriteTimeUtc}_{m.Length}");
        }


        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("HashCreators")]
        public void CreateFileIdentitiesTest(IIqtHashCreator c)
        {
            IPoorMansIoC ioC = new IqtIoc();
            ioC.Register<IIqtHashCreator>(() => { return c; });

            var fResult = ioC.Get<IIqtIdentityFactory>();
            fResult.ThrowIfException();

            IIqtIdentityFactory fact = fResult.ResultSet;

            DirectoryInfoMock m = new DirectoryInfoMock
            {
                FullName = "c:/klaus.org",
                Name = "klaus.org",
                Length = 400,
                CreationTimeUtc = DateTime.UtcNow,
                ProductName = "MyProduct",
                FileName = "MyProductFileName",
                ProductVersion = "MyProductVersion",
                FileVersion = "MyProductFileVersion",
            };

            var k = fact.Create(m, m);

            Assert.IsFalse(k.Excluded);
            Assert.AreEqual(m.FullName, k.FullName);
            Assert.AreEqual(m.Name, k.Name);
            Assert.NotNull(k.Hash);
            Assert.NotNull(k.QualifiedName, $"{m.FileName}_{m.ProductName}_{m.ProductVersion}_{m.FileVersion}_{m.Length}");
        }
    }
}