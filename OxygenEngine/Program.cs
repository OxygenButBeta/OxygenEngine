 using OxygenEngine.AssetDatabase;
using OxygenEngine.Common.Engine_Plugins;
using OxygenEngineCore;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Rendering;


CancellationTokenSource _asyncEngineServiceToken = new();

EngineService.RaiseService<DataIndexer>(_asyncEngineServiceToken.Token);

using var renderView = new RenderWindow(1280, 720);
renderView.OnAwake += (window) => {
    var mesh = new Mesh(@"b46e55cd-bd7c-46d8-b494-564358dd85f4");
    MeshRenderer meshRenderer = new(mesh, new (@"261fb487-1c2b-47ab-8b5b-f86d3710a7c2"));
    window.DrawCallElements.Add(meshRenderer);
};

renderView.Run();