using OxygenEngine.AssetDatabase;
using OxygenEngine.Common.EnginePlugins;
using OxygenEngineCore.InputSystem;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Primitive.Lib;

namespace OxygenEngineCore;

public class OxygenEngine(int width = 1280, int height = 720) {
    public event Action<OxygenEngine> OnEngineStart;
    public event Action<IEngineService> OnEngineServiceStart;
    public event Action<float> OnEngineUpdate;
    public event Action UI_OverlayUpdate;
    public OpenGL_RenderWindow OpenGlRenderEngine = new(width, height);
    readonly CancellationTokenSource _asyncEngineServiceToken = new();

    public void AttachToRenderQueue(IDrawCallElement drawCallElement) {
        OpenGlRenderEngine.DrawCallElements.Add(drawCallElement);
    }

    public void DetachFromRenderQueue(IDrawCallElement drawCallElement) {
        OpenGlRenderEngine.DrawCallElements.Remove(drawCallElement);
    }


    public void StartEngine() {
        AssetDatabase.Init();
        EngineService.RaiseService<DataIndexer>(_asyncEngineServiceToken.Token);
        OpenGlRenderEngine.OnUpdate += (arg, gl) => { OnEngineUpdate?.Invoke((float)arg.Time); };
        OpenGlRenderEngine.EarlyUpdate += (fa, gl) => Input.Update(gl);
        OpenGlRenderEngine.OnAwake += (window) => { OnEngineStart?.Invoke(this); };
        OpenGlRenderEngine.OPENGL_OverlayUpdate += UI_OverlayUpdate;
        OpenGlRenderEngine.Run();
    }
}