using OxygenEngine.Runtime.Editor.Context_Menu;
using OxygenEngineCore.InputSystem;
using OxygenEngineCore.Primitive;
namespace OxygenEngine.Runtime.Runtime;

public class EngineStarter {
    public static OxygenEngineCore.OxygenEngine engine = new OxygenEngineCore.OxygenEngine();

    public void StartEngine() {
    
        engine.OnEngineUpdate += (deltaTime) => {
            if (Input.IsKeyPressed(Key.Space))
            {
                Console.WriteLine("Space key is pressed");
            }
        };
        engine.UI_OverlayUpdate += () => {
            TopContextOverlay.DrawTopContextMenu();
            ObjectTransformMenu.DrawLeftMenu();
            ObjectTransformMenu.DrawUIClr();
        };
        engine.StartEngine();
    }
}