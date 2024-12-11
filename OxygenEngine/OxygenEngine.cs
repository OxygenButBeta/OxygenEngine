using O2Common.EnginePlugins;
using OxygenEngine.AssetDatabase;
using OxygenEngineCore.InputSystem;


namespace OxygenEngineCore;

public class OxygenEngine {
    public event Action<OxygenEngine> OnEngineStart;
    public event Action<float> OnEngineUpdate;
    public event Action OnUiOverlayUpdate;
    public static GLRenderWindow GlRenderEngine { get; private set; }
    readonly CancellationTokenSource _asyncEngineServiceToken = new();
    public static OxygenEngine Instance { get; private set; }
    public Scene.Scene CurrentScene { get; set; } = new("Default Scene");

    readonly int width, height;

    public OxygenEngine(int width = 1280, int height = 720) {
        Instance = this;
        this.width = width;
        this.height = height;
    }

    public void StartEngine() {
        AssetDatabase.Init();
        EngineService.RaiseService<DataIndexer>(_asyncEngineServiceToken.Token);
        GlRenderEngine = new(width, height);
        GlRenderEngine.OnUpdate += (arg, gl) => {
            OnEngineUpdate?.Invoke((float)arg.Time);
            CurrentScene.Update((float)arg.Time);
        };
        GlRenderEngine.EarlyUpdate += (fa, gl) => Input.Update(gl);
        GlRenderEngine.OnAwake += (window) => { OnEngineStart.Invoke(this); };
        GlRenderEngine.OverlayUpdate += () => OnUiOverlayUpdate.Invoke();
        GlRenderEngine.Run();
    }
}