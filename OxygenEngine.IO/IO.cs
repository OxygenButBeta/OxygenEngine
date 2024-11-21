using OxygenEngine.Database.Meta;

namespace OxygenEngine.IO;

public static class IO {
    public static string GetExactPathFromMeta(MetaData path) {
        return  AppDomain.CurrentDomain.BaseDirectory + @"\" + path.FilePath;
    }
}