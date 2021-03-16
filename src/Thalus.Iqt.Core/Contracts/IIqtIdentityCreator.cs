namespace Thalus.Iqt.Core
{
    public interface IIqtIdentityCreator
    {
        IqtIdentityDTO[] CreateFrom(IIqtExcludesDTO excludes = null, params string[] directories);
    }
}