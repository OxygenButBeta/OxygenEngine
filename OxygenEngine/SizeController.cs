using OxygenEngine.Scripting;
using OxygenEngineCore.InputSystem;

namespace OxygenEngine.Runtime.Scripting;

public class SizeController : CoreBehaviour {
    internal override void OnTick(float deltaTime) {
        Console.WriteLine("Controller OnTick");
        var ScaleVector = worldObject.spatial.Scale * deltaTime;
        if (Input.IsKeyDown(Key.C))
        {
            worldObject.spatial.Scale =
                new OpenTK.Mathematics.Vector3(ScaleVector.X + 0.1f, ScaleVector.Y + 0.1f, ScaleVector.Z + 0.1f);
        }
        else
        {
            if (Input.IsKeyDown(Key.X))
            {
                worldObject.spatial.Scale =
                    new OpenTK.Mathematics.Vector3(ScaleVector.X - 0.1f, ScaleVector.Y - 0.1f, ScaleVector.Z - 0.1f);
            }
        }
    }
}