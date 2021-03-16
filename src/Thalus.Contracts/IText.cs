namespace Thalus.Contracts
{

    public interface IText
    {
        string Encoding { get; }
        string Locale { get; }
        string Localized { get; }
        string Invariant { get; }
    }
}
