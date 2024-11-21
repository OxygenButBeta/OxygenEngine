using Newtonsoft.Json;

namespace OxygenEngine.Database.Meta;

public static class MetaCreator {
    public static MetaData CreateMetaInternal(string path) {
        if (IsMetaExist(path))
            return GetMetaData(path);
        var fileName = Path.GetFileName(path);
        var extension = Path.GetExtension(path);
        var lastModify = File.GetLastWriteTime(path);
        var guid = Guid.NewGuid().ToString();

        Meta.MetaData meta = new(lastModify, guid, extension, path, fileName);
        var targetPath = GetMetaPathFromFilePath(AppDomain.CurrentDomain.BaseDirectory + @"\" + path);
        Console.WriteLine(targetPath);
        File.WriteAllText(targetPath, JsonConvert.SerializeObject(meta, Formatting.Indented));

        return meta;
    }

    internal static MetaData GetMetaData(string path, bool CreateIfNotExist = false) {
        if (IsMetaExist(path))
            return JsonConvert.DeserializeObject<Meta.MetaData>(File.ReadAllText(GetMetaPathFromFilePath(path)));

        return CreateIfNotExist ? CreateMetaInternal(path) : MetaData.Empty;
    }

    internal static string GetMetaPathFromFilePath(string path) {
        var DirPath = Path.GetDirectoryName(path);
        var FileName = Path.GetFileNameWithoutExtension(path);
        return Path.Combine(DirPath, FileName + ".meta");
    }

    internal static bool IsMetaExist(string path) {
        return File.Exists(GetMetaPathFromFilePath(path));
    }
}