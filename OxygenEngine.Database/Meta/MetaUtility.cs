namespace OxygenEngine.Database.Meta;

public static class MetaUtility {
    public static string GetExactPathFromMeta(this MetaData path) {
        Console.WriteLine("Dirr"+AppDomain.CurrentDomain.BaseDirectory + @"\" + path.FilePath);
        return  AppDomain.CurrentDomain.BaseDirectory + @"\" + path.FilePath;
    }
}