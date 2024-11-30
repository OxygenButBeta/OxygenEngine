namespace OxygenEngine.Database.Meta;

public static class MetaUtility {
    public static string GetExactPathFromMeta(this MetaData path) {
        return AppDomain.CurrentDomain.BaseDirectory + @"\" + path.FilePath;
    }

    public static string AssetFolderPath() {
        return AppDomain.CurrentDomain.BaseDirectory + @"\Assets\";
    }
}