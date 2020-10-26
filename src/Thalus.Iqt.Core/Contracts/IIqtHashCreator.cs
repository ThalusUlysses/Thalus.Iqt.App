namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IIqtHashCreator"/> such like
    /// <see cref="CreateHash(string)"/>. Abstracts creation of hash values from 
    /// a specified string. 
    /// </summary>
    public interface IIqtHashCreator
    {
        /// <summary>
        /// Creates a hash value from the passes string
        /// </summary>
        /// <param name="qualifiedName">Pass the data to be hashed</param>
        /// <returns>Retruns the hash value as string</returns>
        string CreateHash(string qualifiedName);
    }
}