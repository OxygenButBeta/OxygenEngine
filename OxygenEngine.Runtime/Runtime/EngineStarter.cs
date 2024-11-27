using OxygenEngine.Runtime.Editor;
using OxygenEngine.Runtime.Editor.Context_Menu;
using OxygenEngineCore.InputSystem;

namespace OxygenEngine.Runtime.Runtime;

public class EngineStarter {
    public static OxygenEngineCore.OxygenEngine engine = new OxygenEngineCore.OxygenEngine();

    public void StartEngine() {
        EditorLoop editorLoop = new EditorLoop();
        engine.OnEngineUpdate += (deltaTime) => {
            if (Input.IsKeyPressed(Key.Space))
            {
                Console.WriteLine("Space key is pressed");
            }
        };
        engine.OnEngineStart += (engine) => { editorLoop.OpenWindows(); };
        engine.OnUiOverlayUpdate += () => { editorLoop.UpdateCallbacks(); };
        engine.StartEngine();
    }
}