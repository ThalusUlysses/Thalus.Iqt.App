namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IIqtIdentityCreator"/> such like
    /// <see cref="CreateFrom(IIqtExcludesDTO, string[])"/>
    /// </summary>
    public interface IIqtIdentityCreator
    {
        /// <summary>
        /// Creates an set of <see cref="IIqtIdentity"/> from passed dirrectores. Considers <see cref="IIqtExcludesDTO"/>
        /// for processing
        /// </summary>
        /// <param name="excludes">Pass the exclude object that defines data which must not be included</param>
        /// <param name="directories">Pass the directories to consider for creation</param>
        /// <returns>Returns a set of <see cref="IIqtIdentity"/></returns>
        IIqtIdentity[] CreateFrom(IIqtExcludes excludes = null, params string[] directories);
    }
}