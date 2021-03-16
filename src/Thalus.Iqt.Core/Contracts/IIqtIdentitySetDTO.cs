using System.Collections.Generic;

namespace Thalus.Iqt.Core
{
    public interface IIqtIdentitySetDTO
    {
        IqtExcludesDTO Excludes { get; set; }
        IqtIdentityDTO[] Identities { get; set; }
    }
}