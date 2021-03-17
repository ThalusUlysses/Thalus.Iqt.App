namespace Thalus.Iqt.Core.Contracts
{
    public interface IIqtIdentitySet
    {
        IIqtExcludes Excludes { get; set; }
        IIqtIdentity[] Identities { get; set; }
    }
}