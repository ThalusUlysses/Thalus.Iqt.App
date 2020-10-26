using System.Collections.Generic;

namespace Thalus.Iqt.Core
{
    public class IqtIdentityResultSetDTO
    {
        public IqtIdentityResultSetDTO()
        {
            ExcludedButNotThere = new List<IqtIdentityResultDTO>();
            ThereButWrongHash = new List<IqtIdentityResultDTO>();
            ThereButNotExpected = new List<IqtIdentityResultDTO>();
            ThereButExcluded = new List<IqtIdentityResultDTO>();
            ExpectedButNotThere = new List<IqtIdentityResultDTO>();
        }

        public List<IqtIdentityResultDTO> ExpectedButNotThere { get; set; }
        
        public List<IqtIdentityResultDTO> ExcludedButNotThere { get; set; }

        public List<IqtIdentityResultDTO> ThereButExcluded { get; set; }

        public List<IqtIdentityResultDTO> ThereButNotExpected { get; set; }

        public List<IqtIdentityResultDTO> ThereButWrongHash { get; set; }
    }
}
