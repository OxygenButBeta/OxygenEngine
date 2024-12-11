using OpenTK.Mathematics;
using OxygenEngine.Scripting;
using OxygenEngine.Serialization;
using OxygenEngineCore.InputSystem;

namespace Runtime;

public class Controller : CoreBehaviour {
    [SerializedField] private float speed = 1.0f;

    internal override void OnTick(float deltaTime) {
        Vector3 nextPos = Transform.Position;
        if (Input.IsKeyDown(Key.Up))
        {
            nextPos.Z -= speed*deltaTime;
        }

        if (Input.IsKeyDown(Key.Down))
        {
            nextPos.Z += speed*deltaTime;
        }

        if (Input.IsKeyDown(Key.Left))
        {
            nextPos.X -= speed*deltaTime;
        }

        if (Input.IsKeyDown(Key.Right))
        {
            nextPos.X += speed*deltaTime;
        }

        Transform.Position = nextPos;
    }
}