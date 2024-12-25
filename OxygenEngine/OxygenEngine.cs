using O2Common.EnginePlugins;
using OxygenEngine.AssetDatabase;
using OxygenEngineCore.InputSystem;

namespace OxygenEngineCore;

public class OxygenEngine {
    public event Action<OxygenEngine> OnEngineStart;
    public event Action<float> OnEngineUpdate;
    public event Action OnUiOverlayUpdate;
    public static IGL IGL { get; private set; }
    public static OxygenEngine Instance { get; private set; }
    public Scene.Scene CurrentScene { get; set; } = new("Default Scene");

    
    readonly int width, height;
    readonly CancellationTokenSource _asyncEngineServiceToken = new();
    public OxygenEngine(int width = 1280, int height = 720) {
        Instance = this;
        this.width = width;
        this.height = height;
    }

    public void StartEngine() {
        AssetDatabase.Init();
        EngineService.RaiseService<DataIndexer>(_asyncEngineServiceToken.Token);
        
        IGL = new(width, height);
        IGL.OnUpdate += (arg, gl) => {
            OnEngineUpdate?.Invoke((float)arg.Time);
            CurrentScene.Update((float)arg.Time);
        };
        IGL.EarlyUpdate += (fa, gl) => Input.Update(gl);
        IGL.OnAwake += (window) => { OnEngineStart.Invoke(this); };
        IGL.OverlayUpdate += () => OnUiOverlayUpdate.Invoke();
        IGL.Run();
    }
}