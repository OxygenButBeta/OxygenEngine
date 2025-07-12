namespace OxygenEngine.Database.Meta;

//TODO: Implement a proper meta utility
public static class MetaUtility {
    public static string GetExactPathFromMeta(this MetaData path) {
        return AppDomain.CurrentDomain.BaseDirectory + @"\" + path.FilePath;
    }

    public static string  AssetFolderPath() {
        return AppDomain.CurrentDomain.BaseDirectory + @"\Assets\";
    }
}