using OxygenEngine.Database.Meta;

namespace OxygenEngine.Database.Asset_Database;

public static class AssetDatabase {
    public static IEnumerable<MetaData> IndexedAssets => _assets;
    private static List<MetaData> _assets = [];

    internal static void AddAsset(MetaData asset) {
        if (_assets.Contains(asset))
            return;

        _assets.Add(asset);
    }

    public static void UpdateMetaDataLibrary(List<MetaData> assets) {
        _assets = assets;
    }
}