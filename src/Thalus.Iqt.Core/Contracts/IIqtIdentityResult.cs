namespace Thalus.Iqt.Core.Contracts
{
    public interface IIqtIdentityResult
    {
        IIqtIdentity Current { get; set; }
        IIqtIdentity Expected { get; set; }
        string Text { get; set; }
    }
}