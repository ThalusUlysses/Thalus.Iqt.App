namespace Thalus.Iqt.Core
{
    public interface IIqtIdentityResultDTO
    {
        IIqtIdentityDTO Current { get; set; }
        IIqtIdentityDTO Expected { get; set; }
        string Text { get; set; }
    }
}