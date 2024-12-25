using O2Common.EnginePlugins;
using OxygenEngine.AssetDatabase;
using OxygenEngine.Database.Meta;

namespace OxygenEngine.AssetDatabase;

/// <summary>
/// DataIndexer is a service that indexes the assets in the project directory.
/// </summary>
public sealed partial  class DataIndexer : IAsyncEngineService<DataIndexer> {
    readonly CancellationToken token;
    const int IndexInterval = 3000;

    public DataIndexer RaiseService(CancellationToken token) {
        if (!Directory.Exists("Assets"))
            Directory.CreateDirectory("Assets");
        return new DataIndexer(token);
    }

    public DataIndexer() {
        List<MetaData> assets = new(100);
        assets.AddRange(from file in Directory.GetFiles(@"Assets", "*.*", SearchOption.AllDirectories)
            where TargetTypes.Contains(Path.GetExtension(file))
            select MetaCreator.GetMetaData(file, true));

        AssetDatabase.UpdateMetaDataLibrary(assets);
    }

    DataIndexer(CancellationToken token) {
        this.token = token;
        Task.Run(IndexDataAsync, token);
    }

    /// <summary>
    /// Repetitively indexes the assets in the project directory.
    /// </summary>
    async Task IndexDataAsync() {
        while (!token.IsCancellationRequested)
        {
            List<MetaData> assets = new(100);
            assets.AddRange(from file in Directory.GetFiles(@"Assets", "*.*", SearchOption.AllDirectories)
                where TargetTypes.Contains(Path.GetExtension(file))
                where !MetaCreator.IsMetaExist(file)
                select MetaCreator.CreateMetaInternal(file));

            if (assets.Count > 0)
                AssetDatabase.UpdateMetaDataLibrary(assets);
            await Task.Delay(IndexInterval, token);
        }
    }
}