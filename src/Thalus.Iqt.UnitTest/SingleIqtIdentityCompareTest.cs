using NUnit.Framework;
using System.Linq;
using Thalus.Iqt.Core;
using Thalus.Iqt.Core.Contracts;
using Thalus.Iqt.Core.Contracts.DTO;

namespace Thalus.Iqt.UnitTest
{
    [TestFixture]
    public class SingleIqtIdentityCompareTest
    {
        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityEqualTest()
        {
            IPoorMansIoC ioC = new IqtIoc();

            var cResult = ioC.Get<IIqtIdentityCompare>();
            cResult.ThrowIfException();

            IIqtIdentityCompare c = cResult.ResultSet;

            IqtIdentityDTO dto = new IqtIdentityDTO
            {
                Excluded = false,
                FullName = "12345",
                Hash = "23456789",
                Name = "MyName",
                QualifiedName = "23456789"
            };

            var result = c.CompareIdentity(dto, dto);
            Assert.True(result.Success);
            Assert.AreEqual(0, result.Code);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityNotEqualTest()
        {
            IPoorMansIoC ioC = new IqtIoc();

            var cResult = ioC.Get<IIqtIdentityCompare>();
            cResult.ThrowIfException();

            IIqtIdentityCompare c = cResult.ResultSet;

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

            var result = c.CompareIdentity(dto, dto2);
            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityNotEqualHashTest()
        {
            IPoorMansIoC ioC = new IqtIoc();

            var cResult = ioC.Get<IIqtIdentityCompare>();
            cResult.ThrowIfException();

            IIqtIdentityCompare c = cResult.ResultSet;

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


            var result = c.CompareIdentity(dto, dto2);
            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(1, data.ThereButWrongHash.Count());
            Assert.AreEqual(0, data.ThereButNotExpected.Count());
            Assert.AreEqual(0, data.ThereButExcluded.Count());
            Assert.AreEqual(0, data.ExcludedButNotThere.Count());
            Assert.AreEqual(0, data.ExpectedButNotThere.Count());
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityThereButExcludedTest()
        {
            IPoorMansIoC ioC = new IqtIoc();

            var cResult = ioC.Get<IIqtIdentityCompare>();
            cResult.ThrowIfException();

            IIqtIdentityCompare c = cResult.ResultSet;

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



            var result = c.CompareIdentity(dto, dto2);
            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(0, data.ThereButWrongHash.Count());
            Assert.AreEqual(0, data.ThereButNotExpected.Count());
            Assert.AreEqual(1, data.ThereButExcluded.Count());
            Assert.AreEqual(0, data.ExcludedButNotThere.Count());
            Assert.AreEqual(0, data.ExpectedButNotThere.Count());
        }

        [Test(Author = "ThalusUlysses", Description = "Checks")]
        public void CompareIdentityExpectedButNotThereTest()
        {
            IPoorMansIoC ioC = new IqtIoc();

            var cResult = ioC.Get<IIqtIdentityCompare>();
            cResult.ThrowIfException();

            IIqtIdentityCompare c = cResult.ResultSet;

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



            var result = c.CompareIdentity(dto, dto2);
            Assert.True(result.Success);
            Assert.AreEqual(402, result.Code);
            var data = result.GetData<IqtIdentityResultSetDTO>();

            Assert.AreEqual(0, data.ThereButWrongHash.Count());
            Assert.AreEqual(0, data.ThereButNotExpected.Count());
            Assert.AreEqual(0, data.ThereButExcluded.Count());
            Assert.AreEqual(0, data.ExcludedButNotThere.Count());
            Assert.AreEqual(1, data.ExpectedButNotThere.Count());
        }
    }
}