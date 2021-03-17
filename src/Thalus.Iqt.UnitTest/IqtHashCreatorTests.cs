using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;
using Thalus.Iqt.Core;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class IqtHashCreatorTests
    {
        public static HashAlgorithm[] Creators { get; set; } = new HashAlgorithm[] { SHA1.Create(), SHA256.Create() };

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("Creators")]
        public void CreateHashWithoutExcepionTest(HashAlgorithm creator)
        {
            var ioC = new IqtIoc();
            ioC.Register<HashAlgorithm>(() => { return creator; });

            var rHashCreator = ioC.Get<IIqtHashCreator>();
            rHashCreator.ThrowIfException();

            IIqtHashCreator c = rHashCreator.ResultSet;
            var hash = creator.ComputeHash(Encoding.UTF8.GetBytes("klaus"));

            var k = BitConverter.ToString(hash);

            var hsh = c.CreateHash("klaus");

            Assert.IsNotNull(hsh);
            Assert.AreEqual(k, hsh);
        }
    }
}