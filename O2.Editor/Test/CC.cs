using OpenTK.Mathematics;
using OxygenEngine.Scripting;
using OxygenEngine.Serialization;
using OxygenEngineCore.InputSystem;

namespace OxygenEngineCore.Test;

public class CC : CoreBehaviour {
    [SerializedField] public float speed = 1;

    internal override void OnTick(float deltaTime) {
        Vector3 pos = new Vector3(0, 0, 0);
        if (Input.IsKeyDown(Key.Up)){
            pos.X += 1;
        }

        if (Input.IsKeyDown(Key.Down)){
            pos.X -= 1;
        }

        if (Input.IsKeyDown(Key.Left)){
            pos.Z += 1;
        }

        if (Input.IsKeyDown(Key.Right)){
            pos.Z -= 1;
        }

        transform.Position += pos * deltaTime * speed;
    }
}