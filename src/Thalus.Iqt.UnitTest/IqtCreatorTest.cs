using NUnit.Framework;
using System.Linq;
using Thalus.Iqt.Core;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class IqtCreatorTest
    {
        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CreateIdentitiesTest()
        {
            var ioC = new IqtIoc();
            ioC.Register<IIoAccess>(() => { return new FileAccessMock(false); });

            var rCreator = ioC.Get<IIqtIdentityCreator>();
            rCreator.ThrowIfException();

            IIqtIdentityCreator c = rCreator.ResultSet;
            var k = c.CreateFrom(null, "c:/klaus");

            Assert.AreEqual(2, k.Length);

            foreach (var item in k)
            {
                Assert.NotNull(item.FullName);
                Assert.NotNull(item.Hash);
                Assert.NotNull(item.Name);
                Assert.NotNull(item.QualifiedName);
            }
        }

        public static IqtExcludesDTO[] FileExcludes { get; set; } = new[]
        {
            new IqtExcludesDTO { Files = new[] { "c:/klaus/myfile.org" } },
            new IqtExcludesDTO { FileNamePatterns = new [] { ".*yfile.+" } },
            new IqtExcludesDTO { FileEndings = new [] {".org" } }
        };

        public static IqtExcludesDTO[] DirectoryExcludes { get; set; } = new[]
      {
            new IqtExcludesDTO { Direcories = new[] { "c:/klaus" } },
            new IqtExcludesDTO { DirectoryNamePatterns = new[] { ".*klaus.|.+" } },
        };

        public static IqtExcludesDTO[] GetExcludes()
        {
            return DirectoryExcludes.Concat(FileExcludes).ToArray();
        }

        public static IqtExcludesDTO[] Exclude { get; set; } = new IqtExcludesDTO[]
        {
            new IqtExcludesDTO
            {
                Files = new[] { "c:/klaus/myfile.org" } , FileNamePatterns = new[] { ".*yfile.+" }, FileEndings = new[] { ".org" },
                Direcories = new[] { "c:/klaus" }, DirectoryNamePatterns = new[] { ".*klaus.|.+" }
            }
        };


        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("DirectoryExcludes")]

        public void CreateIdentitiesExcludeDirectoryTest(IqtExcludesDTO ex)
        {
            var ioC = new IqtIoc();
            ioC.Register<IIoAccess>(() => { return new FileAccessMock(false); });

            var rCreator = ioC.Get<IIqtIdentityCreator>();
            rCreator.ThrowIfException();

            IIqtIdentityCreator c = rCreator.ResultSet;
            var k = c.CreateFrom(ex, "c:/klaus");

            var item = k.First(i => i.FullName.Equals("c:/klaus"));

            Assert.AreEqual(2, k.Length);

            Assert.IsTrue(item.Excluded);
            Assert.NotNull(item.FullName);
            Assert.NotNull(item.Hash);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.QualifiedName);
        }


        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("Exclude")]

        public void CreateIdentitiesExcludeAllTest(IqtExcludesDTO ex)
        {
            var ioC = new IqtIoc();
            ioC.Register<IIoAccess>(() => { return new FileAccessMock(false); });

            var rCreator = ioC.Get<IIqtIdentityCreator>();
            rCreator.ThrowIfException();

            IIqtIdentityCreator c = rCreator.ResultSet;
            var k = c.CreateFrom(ex, "c:/klaus");

            Assert.AreEqual(2, k.Length);

            foreach (var item in k)
            {
                Assert.IsTrue(item.Excluded);
                Assert.NotNull(item.FullName);
                Assert.NotNull(item.Hash);
                Assert.NotNull(item.Name);
                Assert.NotNull(item.QualifiedName);
            }
        }
    }
}