namespace Thalus.Contracts
{
    /// <summary>
    /// Indicates that the object has an <see cref="IText"/> Property that deliveres localized information
    /// </summary>
    public interface IProvideText
    {
        /// <summary>
        /// returns a localized and invariant text descripton with locale ("en-US, de-DE",...)
        /// </summary>
        IText GetText();
    }
}


