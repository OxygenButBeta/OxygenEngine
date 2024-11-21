using OxygenEngine.Common.Engine_Plugins;
using OxygenEngine.Database.Asset_Database;
using OxygenEngine.Database.Meta;

namespace OxygenEngine.Database.Indexer;

public partial class DataIndexer : AsyncEngineService<DataIndexer> {
    readonly CancellationToken token;
    const int IndexInterval = 1000;

    public DataIndexer RaiseService(CancellationToken token) {
        if (!Directory.Exists("Assets"))
            Directory.CreateDirectory("Assets");
        return new DataIndexer(token);
    }

    public DataIndexer() {
        List<MetaData> assets = new(100);
        assets.AddRange(from file in Directory.GetFiles(@"Assets")
            where TargetTypes.Contains(Path.GetExtension(file))
            select MetaCreator.GetMetaData(file, true));
        
        AssetDatabase.UpdateMetaDataLibrary(assets);
    }

    DataIndexer(CancellationToken token) {
        this.token = token;
        Task.Run(IndexData, token);
    }

    async Task IndexData() {
        while (!token.IsCancellationRequested)
        {
            List<MetaData> assets = new(100);
            foreach (var file in Directory.GetFiles(@"Assets"))
            {
                if (!TargetTypes.Contains(Path.GetExtension(file)))
                    continue;

                if (!MetaCreator.IsMetaExist(file))
                    assets.Add(MetaCreator.CreateMetaInternal(file));
            }

            if (assets.Count > 0)
                AssetDatabase.UpdateMetaDataLibrary(assets);
            await Task.Delay(IndexInterval, token);
        }
    }
}