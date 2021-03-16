namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IIqtIdentityFactory"/> such like
    /// <see cref="Create(IDirectoryInfo, bool)"/>
    /// </summary>
    public interface IIqtIdentityFactory
    {
        /// <summary>
        /// Creates an <see cref="IqtIdentityDTO"/> for a specific <see cref="IDirectoryInfo"/>
        /// </summary>
        /// <param name="di">Pass the <see cref="IDirectoryInfo"/> to create an identity from</param>
        /// <param name="includeDirectoryCreationTime">Includes the creation time of a directory as identity attribute when true</param>
        /// <returns>Returns an <see cref="IqtIdentityDTO"/> representation of the passed values</returns>
        IqtIdentityDTO Create(IDirectoryInfo di, bool includeDirectoryCreationTime);


        /// <summary>
        /// Creates an <see cref="IqtIdentityDTO"/> for a specific <see cref="IFileInfo"/> and <see cref="IFileVersionInfo"/>
        /// </summary>
        /// <param name="fi">Pass the <see cref="IFileInfo"/> to create an identity from</param>
        /// <param name="fvi">Pass the <see cref="IFileVersionInfo"/> to create an identity from</param>
        /// <returns>Returns an <see cref="IqtIdentityDTO"/> representation of the passed values</returns>
        IqtIdentityDTO Create(IFileInfo fi, IFileVersionInfo fvi);
    }
}