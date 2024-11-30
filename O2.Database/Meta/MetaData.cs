// ReSharper disable NotAccessedPositionalProperty.Global

namespace OxygenEngine.Database.Meta;

[Serializable]
public readonly record struct MetaData : IEqualityComparer<MetaData> {
    public readonly string FileName;
    public readonly string FilePath;
    public readonly string FileExtension;
    public readonly string FileGuid;
    public readonly DateTime LastModified;

    public MetaData(DateTime lastModified, string fileGuid, string fileExtension, string filePath, string fileName) {
        LastModified = lastModified;
        FileGuid = fileGuid;
        FileExtension = fileExtension;
        FilePath = filePath;
        FileName = fileName;
    }



    public static readonly MetaData Empty = new MetaData(DateTime.MinValue, string.Empty, string.Empty, string.Empty,
        string.Empty);


    public bool Equals(MetaData x, MetaData y) {
        return x.FileGuid == y.FileGuid;
    }

    public int GetHashCode(MetaData obj) {
        return HashCode.Combine(obj.FileName, obj.FilePath, obj.FileExtension, obj.FileGuid, obj.LastModified);
    }
}