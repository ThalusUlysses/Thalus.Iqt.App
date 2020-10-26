using System;

namespace Thalus.Iqt.Core.Contracts

{
    /// <summary>
    /// Publishes the public members of <see cref="IFileInfo"/> such like
    /// <see cref="Extension"/> or <see cref="FullName"/>. 
    /// The <see cref="IFileInfo"/> covers the lack of some <see cref="System.IO"/> functions that are unmockable
    /// </summary>
    public interface IFileInfo
    {
        /// <summary>
        /// Gets the extension of a file as string, similar to <see cref="System.IO.FileSystemInfo.Extension"/>
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Gets the full name of a file as string, similar to <see cref="System.IO.FileSystemInfo.FullName"/>
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the last writing time UTC of a file, similar to <see cref="System.IO.FileSystemInfo.LastWriteTimeUtc"/>
        /// </summary>
        DateTime LastWriteTimeUtc { get; }

        /// <summary>
        /// Get sthe length of a file in bytes, similar to <see cref="System.IO.FileInfo.Length"/>
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets the file name of a file as string, similar to <see cref="System.IO.FileInfo.Name"/>
        /// </summary>
        string Name { get; }
    }
}