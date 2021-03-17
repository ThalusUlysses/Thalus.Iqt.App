namespace Thalus.Iqt.Core.Contracts.DTO
{
    public class IqtIdentityDTO : IIqtIdentity
    {
        public string QualifiedName { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public string Hash { get; set; }

        public bool Excluded { get; set; }
    }
}
