namespace Thalus.Iqt.Core
{
    public class IqtIdentityResultDTO : IIqtIdentityResultDTO
    {
        public IIqtIdentityDTO Expected { get; set; }

        public IIqtIdentityDTO Current { get; set; }

        public string Text { get; set; }
    }
}
