using System.Collections.Generic;

namespace Thalus.Iqt.Core
{
    public interface IIqtIdentityResultSetDTO
    {

        void AddExpectedButNotThere(IqtIdentityResultDTO dto);

        void AddExcludedButNotThere(IqtIdentityResultDTO dto);

        void AddThereButExcluded(IqtIdentityResultDTO dto);

        void AddThereButNotExpected(IqtIdentityResultDTO dto);

        void AddThereButWrongHash(IqtIdentityResultDTO dto);

        List<IqtIdentityResultDTO> ExcludedButNotThere { get; set; }
        List<IqtIdentityResultDTO> ExpectedButNotThere { get; set; }
        List<IqtIdentityResultDTO> ThereButExcluded { get; set; }
        List<IqtIdentityResultDTO> ThereButNotExpected { get; set; }
        List<IqtIdentityResultDTO> ThereButWrongHash { get; set; }
    }
}