using System.Text;
using Thalus.Contracts;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IIoAccess"/> such like
    /// <see cref="GetDirectories(string)"/> or <see cref="ReadAllText(string, Encoding)"/>.
    /// The <see cref="IIoAccess"/> covers the lack of some IO functions are un mockable for testing
    /// </summary>
    public interface IIoAccess
    {
        /// <summary>
        ///  Gets directory information for a specific folder by name
        /// </summary>
        /// <param name="fullName">Pass the full name of the directory</param>
        /// <returns>Returns the <see cref="IDirectoryInfo"/> representation for the passed directory name</returns>
        IDirectoryInfo GetDirectoryInfoFor(string fullName);

        /// <summary>
        ///  Gets file information for a specific item by name
        /// </summary>
        /// <param name="fullName">Pass the full name of the file</param>
        /// <returns>Returns the <see cref="IFileInfo"/> representation for the passed file name</returns>
        IFileInfo GetFileInfo(string fileName);

        /// <summary>
        /// Gets the file version information for a specific file by name
        /// </summary>
        /// <param name="fileName">Pass the full name of the file</param>
        /// <returns>Returns the <see cref="IFileVersionInfo"/> representation for the passed file name</returns>
        IFileVersionInfo GetVersionInfoOf(string fileName);

        /// <summary>
        /// Reads all text from a specific file by name
        /// </summary>
        /// <param name="fileName">Pass the full name of the file</param>
        /// <param name="enc">Pass the encoding of the file / text. Default is <see cref="Encoding.UTF8"/></param>
        /// <returns>Returns the file data as <see cref="IResult"/> where <see cref="IResult.Data"/> is type of string</returns>
        /// <remarks>
        /// 404 -> File or location not found
        /// 200 -> Ok. Created a new file
        /// </remarks>
        IResult ReadAllText(string fileName, Encoding enc = null);

        /// <summary>
        /// Writes all text to a specific file by name
        /// </summary>
        /// <param name="text">Pass the text to write</param>
        /// <param name="fileName">Pass the full name of the file</param>
        /// <param name="overwrite">Pass the force / overwrite flag. Default = <see cref="true"/></param>
        /// <param name="enc">Pass the encoding of the file / text. Default is <see cref="Encoding.UTF8"/></param>
        /// <returns>Returns the file write result as <see cref="IResult"/></returns>
        /// <remarks>
        /// 403 -> Forbidden. File already exists or you have insufficient rights to write at location
        /// 200 -> Ok. Created a new file
        /// 203 -> Ok, Overwritten an existing file
        /// </remarks>
        IResult WriteAllText(string text, string fileName, bool overwrite = false, Encoding enc = null);

        /// <summary>
        /// Gets all filenames of a directory similar to <see cref="System.IO.DirectoryInfo.GetFiles"/>
        /// </summary>
        /// <param name="directory">Pass the directory full name to get files for</param>
        /// <returns>Retruns an <see cref="string[]"/> of qualified full names</returns>
        string[] GetFileNames(string directory);

        /// <summary>
        /// Gets all folder names of a directory similar to <see cref="System.IO.DirectoryInfo.GetDirectories"/>
        /// </summary>
        /// <param name="dirName">Pass the directory full name to get sub directories for</param>
        /// <returns>Returns a <see cref="string[]"/> of qulified full names</returns>
        string[] GetDirectories(string dirName);
    }
}