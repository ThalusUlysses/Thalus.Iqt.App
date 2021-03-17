namespace Thalus.Iqt.Core.Contracts.DTO
{
    public class IqtIdentitySetDTO : IIqtIdentitySet
    {
        public IIqtIdentity[] Identities { get; set; }

        public IIqtExcludes Excludes { get; set; }
    }
}
