using OxygenEngineCore.InputSystem;
using Runtime.Editor;

namespace Runtime.Runtime;

public class Editor {
    static readonly OxygenEngineCore.OxygenEngine engine = new();

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