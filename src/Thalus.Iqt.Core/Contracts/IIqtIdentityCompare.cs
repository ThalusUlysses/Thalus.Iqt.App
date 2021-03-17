using Thalus.Contracts;

namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IIqtIdentityCompare"/> such like
    /// <see cref="CompareIdentities(IIqtIdentity[], IIqtIdentity[])"/>
    /// </summary>
    public interface IIqtIdentityCompare
    {
        /// <summary>
        /// Compares identities based of th th expected and current values
        /// </summary>
        /// <param name="expected">Pass the expected values or reference</param>
        /// <param name="current">Pass the current values</param>
        /// <returns></returns>
        IResult CompareIdentities(IIqtIdentity[] expected, IIqtIdentity[] current);

        /// <summary>
        /// Compares a single identity of expected and current value
        /// </summary>
        /// <param name="expected">Pass the expected value</param>
        /// <param name="current">Pass the current value</param>
        /// <returns></returns>
        IResult CompareIdentity(IIqtIdentity expected, IIqtIdentity current);

        /// <summary>
        /// Compares a complete set of values with exclude information of expected and current
        /// values
        /// </summary>
        /// <param name="expected">Pass the expected set of values here</param>
        /// <param name="current">Pass  the current set of values here</param>
        /// <returns></returns>
        IResult CompareIdentitySet(IIqtIdentitySet expected, IIqtIdentitySet current);
    }
}