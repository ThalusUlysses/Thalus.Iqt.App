using Thalus.Contracts;

namespace Thalus.Iqt.Core
{
    public interface IIqtIdentityCompare
    {
        IResult CompareIdentities(IIqtIdentityDTO[] expected, IIqtIdentityDTO[] current);
        IResult CompareIdentity(IIqtIdentityDTO expected, IIqtIdentityDTO current);
        IResult CompareIdentitySet(IIqtIdentitySetDTO expected, IIqtIdentitySetDTO current);
    }
}