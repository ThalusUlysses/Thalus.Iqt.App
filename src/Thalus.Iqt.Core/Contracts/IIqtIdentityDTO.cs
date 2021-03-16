namespace Thalus.Iqt.Core
{
    public interface IIqtIdentityDTO
    {
        bool Excluded { get; set; }
        string FullName { get; set; }
        string Hash { get; set; }
        string Name { get; set; }
        string QualifiedName { get; set; }
    }
}