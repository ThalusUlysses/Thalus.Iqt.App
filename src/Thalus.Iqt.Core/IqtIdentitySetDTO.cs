using System.Collections.Generic;

namespace Thalus.Iqt.Core
{
    public class IqtIdentitySetDTO : IIqtIdentitySetDTO
    {
        public IqtIdentityDTO[] Identities { get; set; }

        public IqtExcludesDTO Excludes { get; set; }
    }
}
