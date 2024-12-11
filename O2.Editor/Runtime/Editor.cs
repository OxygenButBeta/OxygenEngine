using OxygenEngineCore.InputSystem;
using Runtime.Editor;

namespace Runtime.Runtime;

public class Editor {
    static readonly OxygenEngineCore.OxygenEngine engine = new();

    public void StartEngine() {
        var editorLoop = new EditorLoop();
        engine.OnEngineStart += (engine) => { editorLoop.OpenWindows(); };
        engine.OnUiOverlayUpdate += () => { editorLoop.UpdateCallbacks(); };
        engine.StartEngine();
    }
}