using OxygenEngine.Database.Meta;

namespace OxygenEngine.AssetDatabase;

public static class AssetDatabase {
    public static IEnumerable<MetaData> IndexedAssets => _assets;
    private static List<MetaData> _assets = [];
    static bool IsInitialized;

    public static void Init() {
        List<MetaData> assets = new(100);
        assets.AddRange(from file in Directory.GetFiles(@"Assets", "*.*", SearchOption.AllDirectories)
            where DataIndexer.TargetTypes.Contains(Path.GetExtension(file))
            select MetaCreator.GetMetaData(file, true));

        UpdateMetaDataLibrary(assets);
        IsInitialized = true;

    }

    internal static void AddAsset(MetaData asset) {
        if (_assets.Contains(asset))
            return;

        _assets.Add(asset);
    }

    public static void UpdateMetaDataLibrary(List<MetaData> assets) {
        _assets = assets;
    }

    public static MetaData GuidToMetaData(string guid) {
        if (!IsInitialized)
            Init();
        
        return _assets.Find(a => a.FileGuid == guid);
    }
}