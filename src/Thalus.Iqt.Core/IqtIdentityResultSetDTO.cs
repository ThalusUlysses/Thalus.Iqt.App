using System.Collections.Generic;
using System.Linq;

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

        public List<IqtIdentityResultDTO> ExpectedButNotThere { get; set; }

        public List<IqtIdentityResultDTO> ExcludedButNotThere { get; set; }

        public List<IqtIdentityResultDTO> ThereButExcluded { get; set; }

        public List<IqtIdentityResultDTO> ThereButNotExpected { get; set; }

        public List<IqtIdentityResultDTO> ThereButWrongHash { get; set; }       
    }
}
