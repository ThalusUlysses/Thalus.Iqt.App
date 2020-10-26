using System;

namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IDirectoryInfo"/> such like
    /// <see cref="FullName"/> or <see cref="CreationTimeUtc"/>. Basically this 
    /// covers the <see cref="System.IO.DirectoryInfo"/> lack of beeing mockable to
    /// Unit tests.
    /// </summary>
    public interface IDirectoryInfo
    {
        /// <summary>
        /// Gets the creation time of the folder as <see cref="System.DateTime.UtcNow"/>
        /// </summary>
        DateTime CreationTimeUtc { get; }

        /// <summary>
        /// Gets the qualified full name of the Directory
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the name of the directory
        /// </summary>
        string Name { get; }
    }
}