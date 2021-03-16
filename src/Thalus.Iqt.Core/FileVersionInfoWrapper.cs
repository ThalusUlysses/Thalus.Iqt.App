using System.Diagnostics;
using Thalus.Iqt.Core.Contracts;

namespace Thalus.Iqt.Core
{
    class FileVersionInfoWrapper : IFileVersionInfo
    {
        FileVersionInfo _fi;

        public FileVersionInfoWrapper()
        {
        }

        public FileVersionInfoWrapper(FileVersionInfo fi)
        {
            _fi = fi;
        }

        //
        // Summary:
        //     Gets a value that specifies whether the file is a development version, rather
        //     than a commercially released product.
        //
        // Returns:
        //     true if the file is prerelease; otherwise, false.
        public bool IsPreRelease => _fi.IsPreRelease;
        //
        // Summary:
        //     Gets the private part number of the product this file is associated with.
        //
        // Returns:
        //     A value representing the private part number of the product this file is associated
        //     with or null if the file did not contain version information.
        public int ProductPrivatePart => _fi.ProductPrivatePart;
        //
        // Summary:
        //     Gets the name of the product this file is distributed with.
        //
        // Returns:
        //     The name of the product this file is distributed with or null if the file did
        //     not contain version information.
        public string ProductName => _fi.ProductName;
        //
        // Summary:
        //     Gets the minor part of the version number for the product the file is associated
        //     with.
        //
        // Returns:
        //     A value representing the minor part of the product version number or null if
        //     the file did not contain version information.
        public int ProductMinorPart => _fi.ProductMinorPart;
        //
        // Summary:
        //     Gets the major part of the version number for the product this file is associated
        //     with.
        //
        // Returns:
        //     A value representing the major part of the product version number or null if
        //     the file did not contain version information.
        public int ProductMajorPart => _fi.ProductMajorPart;
        //
        // Summary:
        //     Gets the build number of the product this file is associated with.
        //
        // Returns:
        //     A value representing the build number of the product this file is associated
        //     with or null if the file did not contain version information.
        public int ProductBuildPart => _fi.ProductBuildPart;
        //
        // Summary:
        //     Gets information about a private version of the file.
        //
        // Returns:
        //     Information about a private version of the file or null if the file did not contain
        //     version information.
        public string PrivateBuild => _fi.PrivateBuild;
        //
        // Summary:
        //     Gets the name the file was created with.
        //
        // Returns:
        //     The name the file was created with or null if the file did not contain version
        //     information.
        public string OriginalFilename => _fi.OriginalFilename;
        //
        // Summary:
        //     Gets the trademarks and registered trademarks that apply to the file.
        //
        // Returns:
        //     The trademarks and registered trademarks that apply to the file or null if the
        //     file did not contain version information.
        public string LegalTrademarks => _fi.LegalTrademarks;
        //
        // Summary:
        //     Gets all copyright notices that apply to the specified file.
        //
        // Returns:
        //     The copyright notices that apply to the specified file.
        public string LegalCopyright => _fi.LegalCopyright;
        //
        // Summary:
        //     Gets the default language string for the version info block.
        //
        // Returns:
        //     The description string for the Microsoft Language Identifier in the version resource
        //     or null if the file did not contain version information.
        public string Language => _fi.Language;
        //
        // Summary:
        //     Gets a value that specifies whether the file is a special build.
        //
        // Returns:
        //     true if the file is a special build; otherwise, false.
        public bool IsSpecialBuild => _fi.IsSpecialBuild;
        //
        // Summary:
        //     Gets a value that specifies whether the file was built using standard release
        //     procedures.
        //
        // Returns:
        //     true if the file is a private build; false if the file was built using standard
        //     release procedures or if the file did not contain version information.
        public bool IsPrivateBuild => _fi.IsPrivateBuild;
        //
        // Summary:
        //     Gets the version of the product this file is distributed with.
        //
        // Returns:
        //     The version of the product this file is distributed with or null if the file
        //     did not contain version information.
        public string ProductVersion => _fi.ProductVersion;
        //
        // Summary:
        //     Gets the special build information for the file.
        //
        // Returns:
        //     The special build information for the file or null if the file did not contain
        //     version information.
        public string SpecialBuild => _fi.SpecialBuild;
        //
        // Summary:
        //     Gets a value that specifies whether the file contains debugging information or
        //     is compiled with debugging features enabled.
        //
        // Returns:
        //     true if the file contains debugging information or is compiled with debugging
        //     features enabled; otherwise, false.
        public bool IsDebug => _fi.IsDebug;
        //
        // Summary:
        //     Gets the internal name of the file, if one exists.
        //
        // Returns:
        //     The internal name of the file. If none exists, this property will contain the
        //     original name of the file without the extension.
        public string InternalName => _fi.InternalName;
        //
        // Summary:
        //     Gets the file version number.
        //
        // Returns:
        //     The version number of the file or null if the file did not contain version information.
        public string FileVersion => _fi.FileVersion;
        //
        // Summary:
        //     Gets the file private part number.
        //
        // Returns:
        //     A value representing the file private part number or null if the file did not
        //     contain version information.
        public int FilePrivatePart => _fi.FilePrivatePart;
        //
        // Summary:
        //     Gets the name of the file that this instance of System.Diagnostics.FileVersionInfo
        //     describes.
        //
        // Returns:
        //     The name of the file described by this instance of System.Diagnostics.FileVersionInfo.
        public string FileName => _fi.FileName;
        //
        // Summary:
        //     Gets the minor part of the version number of the file.
        //
        // Returns:
        //     A value representing the minor part of the version number of the file or 0 (zero)
        //     if the file did not contain version information.
        public int FileMinorPart => _fi.FileMinorPart;
        //
        // Summary:
        //     Gets the major part of the version number.
        //
        // Returns:
        //     A value representing the major part of the version number or 0 (zero) if the
        //     file did not contain version information.
        public int FileMajorPart => _fi.FileMajorPart;
        //
        // Summary:
        //     Gets the description of the file.
        //
        // Returns:
        //     The description of the file or null if the file did not contain version information.
        public string FileDescription => _fi.FileDescription;
        //
        // Summary:
        //     Gets the build number of the file.
        //
        // Returns:
        //     A value representing the build number of the file or null if the file did not
        //     contain version information.
        public int FileBuildPart => _fi.FileBuildPart;
        //
        // Summary:
        //     Gets the name of the company that produced the file.
        //
        // Returns:
        //     The name of the company that produced the file or null if the file did not contain
        //     version information.
        public string CompanyName => _fi.CompanyName;
        //
        // Summary:
        //     Gets the comments associated with the file.
        //
        // Returns:
        //     The comments associated with the file or null if the file did not contain version
        //     information.
        public string Comments => _fi.Comments;
        //
        // Summary:
        //     Gets a value that specifies whether the file has been modified and is not identical
        //     to the original shipping file of the same version number.
        //
        // Returns:
        //     true if the file is patched; otherwise, false.
        public bool IsPatched => _fi.IsPatched;
    }
}
