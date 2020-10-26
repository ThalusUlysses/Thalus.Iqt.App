using NUnit.Framework;
using Thalus.Iqt.Core;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class MultiIqtIdentityCompareTest
    {
        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityEqualTest()
        {
            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityCompare c = new IqtIdentityCompare();

            var result = c.CompareIdentities(new IqtIdentityDTO[] { dto }, new IqtIdentityDTO[] { dto });
            Assert.True(result.Success);
            Assert.AreEqual(0, result.Code);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityNotEqualTest()
        {
            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityDTO dto2 = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "98765432",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityCompare c = new IqtIdentityCompare();

            var result = c.CompareIdentities(new IqtIdentityDTO[] { dto }, new IqtIdentityDTO[] { dto2 });

            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityNotEqualHashTest()
        {
            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityDTO dto2 = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "98765432",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityCompare c = new IqtIdentityCompare();

            var result = c.CompareIdentities(new IqtIdentityDTO[] { dto }, new IqtIdentityDTO[] { dto2 });

            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(1, data.ThereButWrongHash.Count);
            Assert.AreEqual(0, data.ThereButNotExpected.Count);
            Assert.AreEqual(0, data.ThereButExcluded.Count);
            Assert.AreEqual(0, data.ExcludedButNotThere.Count);
            Assert.AreEqual(0, data.ExpectedButNotThere.Count);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityThereButExcludedTest()
        {
            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = true,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityDTO dto2 = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityCompare c = new IqtIdentityCompare();

            var result = c.CompareIdentities(new IqtIdentityDTO[] { dto }, new IqtIdentityDTO[] { dto2 });

            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(0, data.ThereButWrongHash.Count);
            Assert.AreEqual(0, data.ThereButNotExpected.Count);
            Assert.AreEqual(1, data.ThereButExcluded.Count);
            Assert.AreEqual(0, data.ExcludedButNotThere.Count);
            Assert.AreEqual(0, data.ExpectedButNotThere.Count);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityExpectedButNotThereTest()
        {
            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityDTO dto2 = new IqtIdentityDTO
            {
                Excluded = true,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            IqtIdentityCompare c = new IqtIdentityCompare();

            var result = c.CompareIdentities(new IqtIdentityDTO[] { dto }, new IqtIdentityDTO[] { dto2 });

            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(0, data.ThereButWrongHash.Count);
            Assert.AreEqual(0, data.ThereButNotExpected.Count);
            Assert.AreEqual(0, data.ThereButExcluded.Count);
            Assert.AreEqual(0, data.ExcludedButNotThere.Count);
            Assert.AreEqual(1, data.ExpectedButNotThere.Count);
        }
    }
}