// ReSharper disable NotAccessedPositionalProperty.Global

namespace OxygenEngine.Database.Meta;

[Serializable]
public readonly record struct MetaData(
    DateTime LastModified,
    string FileGuid,
    string FileExtension,
    string FilePath,
    string FileName)
    : IEqualityComparer<MetaData> {
    public readonly string FileName = FileName;
    public readonly string FilePath = FilePath;
    public readonly string FileExtension = FileExtension;
    public readonly string FileGuid = FileGuid;
    public readonly DateTime LastModified = LastModified;


    public static readonly MetaData Empty = new MetaData(DateTime.MinValue, string.Empty, string.Empty, string.Empty,
        string.Empty);


    public bool Equals(MetaData x, MetaData y) {
        return x.FileGuid == y.FileGuid;
    }

    public int GetHashCode(MetaData obj) {
        return HashCode.Combine(obj.FileName, obj.FilePath, obj.FileExtension, obj.FileGuid, obj.LastModified);
    }
}