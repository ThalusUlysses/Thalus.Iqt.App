namespace Thalus.Iqt.Core.Contracts.DTO
{
    public class IqtIdentityResultDTO : IIqtIdentityResult
    {
        public IIqtIdentity Expected { get; set; }

        public IIqtIdentity Current { get; set; }

        public string Text { get; set; }
    }
}
