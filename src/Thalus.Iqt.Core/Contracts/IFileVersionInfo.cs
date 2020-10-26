namespace Thalus.Iqt.Core.Contracts

{
    /// <summary>
    /// Publishe sthe public members of <see cref="IFileVersionInfo"/> such like
    /// <see cref="FileName"/> or <see cref="FileVersion"/>.
    /// The <see cref="IFileVersionInfo"/> covers the lack of some <see cref="System.IO"/> functions that are unmockable
    /// </summary>
    public interface IFileVersionInfo
    {
        string Comments { get; }
        string CompanyName { get; }
        int FileBuildPart { get; }
        string FileDescription { get; }
        int FileMajorPart { get; }
        int FileMinorPart { get; }
        string FileName { get; }
        int FilePrivatePart { get; }
        string FileVersion { get; }
        string InternalName { get; }
        bool IsDebug { get; }
        bool IsPatched { get; }
        bool IsPreRelease { get; }
        bool IsPrivateBuild { get; }
        bool IsSpecialBuild { get; }
        string Language { get; }
        string LegalCopyright { get; }
        string LegalTrademarks { get; }
        string OriginalFilename { get; }
        string PrivateBuild { get; }
        int ProductBuildPart { get; }
        int ProductMajorPart { get; }
        int ProductMinorPart { get; }
        string ProductName { get; }
        int ProductPrivatePart { get; }
        string ProductVersion { get; }
        string SpecialBuild { get; }
    }
}