using System.Collections.Generic;

namespace Thalus.Iqt.Core.Contracts.DTO
{
    public class IqtIdentityResultSetDTO : IIqtIdentityResultSet
    {
        public void AddExpectedButNotThere(IIqtIdentityResult dto)
        {
            ExpectedButNotThere.Add(dto);
        }

        public void AddExcludedButNotThere(IIqtIdentityResult dto)
        {
            ExcludedButNotThere.Add(dto);
        }

        public void AddThereButExcluded(IIqtIdentityResult dto)
        {
            ThereButExcluded.Add(dto);
        }

        public void AddThereButNotExpected(IIqtIdentityResult dto)
        {
            ThereButNotExpected.Add(dto);
        }

        public void AddThereButWrongHash(IIqtIdentityResult dto)
        {
            ThereButWrongHash.Add(dto);
        }

        public List<IIqtIdentityResult> ExpectedButNotThere { get; set; } = new List<IIqtIdentityResult>();

        public List<IIqtIdentityResult> ExcludedButNotThere { get; set; } = new List<IIqtIdentityResult>();

        public List<IIqtIdentityResult> ThereButExcluded { get; set; } = new List<IIqtIdentityResult>();

        public List<IIqtIdentityResult> ThereButNotExpected { get; set; } = new List<IIqtIdentityResult>();

        public List<IIqtIdentityResult> ThereButWrongHash { get; set; } = new List<IIqtIdentityResult>();

        IEnumerable<IIqtIdentityResult> IIqtIdentityResultSet.ExcludedButNotThere => ExpectedButNotThere;

        IEnumerable<IIqtIdentityResult> IIqtIdentityResultSet.ExpectedButNotThere => ExcludedButNotThere;

        IEnumerable<IIqtIdentityResult> IIqtIdentityResultSet.ThereButExcluded => ThereButExcluded;

        IEnumerable<IIqtIdentityResult> IIqtIdentityResultSet.ThereButNotExpected => ThereButNotExpected;

        IEnumerable<IIqtIdentityResult> IIqtIdentityResultSet.ThereButWrongHash => ThereButWrongHash;
    }
}
