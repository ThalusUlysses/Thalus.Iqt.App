using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;
using Thalus.Iqt.Core;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class IqtHashCreatorTests
    {
        public static HashAlgorithm[] Creators { get; set; } =  new HashAlgorithm[] { SHA1.Create(), SHA256.Create() };

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        [TestCaseSource("Creators")]
        public void CreateHashWithoutExcepionTest(HashAlgorithm creator)
        {
            IqtHashCreator c = new IqtHashCreator(creator);

            var hash = creator.ComputeHash(Encoding.UTF8.GetBytes("klaus"));

            var k = BitConverter.ToString(hash);

            var hsh = c.CreateHash("klaus");
            
            Assert.IsNotNull(hsh);
            Assert.AreEqual(k, hsh);
        }
    }
}