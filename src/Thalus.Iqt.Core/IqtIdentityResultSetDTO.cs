using System.Collections.Generic;

namespace Thalus.Iqt.Core
{
    public class IqtIdentityResultSetDTO : IIqtIdentityResultSetDTO
    {
        public void AddExpectedButNotThere(IqtIdentityResultDTO dto)
        {
            ExpectedButNotThere.Add(dto);
        }

        public void AddExcludedButNotThere(IqtIdentityResultDTO dto)
        {
            ExcludedButNotThere.Add(dto);
        }

        public void AddThereButExcluded(IqtIdentityResultDTO dto)
        {
            ThereButExcluded.Add(dto);
        }

        public void AddThereButNotExpected(IqtIdentityResultDTO dto)
        {
            ThereButNotExpected.Add(dto);
        }

        public void AddThereButWrongHash(IqtIdentityResultDTO dto)
        {
            ThereButWrongHash.Add(dto);
        }

        public List<IqtIdentityResultDTO> ExpectedButNotThere { get; set; } = new List<IqtIdentityResultDTO>();

        public List<IqtIdentityResultDTO> ExcludedButNotThere { get; set; } = new List<IqtIdentityResultDTO>();

        public List<IqtIdentityResultDTO> ThereButExcluded { get; set; } = new List<IqtIdentityResultDTO>();

        public List<IqtIdentityResultDTO> ThereButNotExpected { get; set; } = new List<IqtIdentityResultDTO>();

        public List<IqtIdentityResultDTO> ThereButWrongHash { get; set; } = new List<IqtIdentityResultDTO>();
    }
}
