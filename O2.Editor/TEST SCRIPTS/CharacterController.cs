using OxygenEngine.Scripting;
using OxygenEngine.Serialization;
using OxygenEngineCore.InputSystem;

namespace Runtime;

public class CharacterController : CoreBehaviour {
    [SerializedField] private float speed = 1.0f;

    internal override void OnTick(float deltaTime) {
        var nextPos = transform.Position;

        if (Input.IsKeyDown(Key.Up))
            nextPos.Z -= speed * deltaTime;

        if (Input.IsKeyDown(Key.Down))
            nextPos.Z += speed * deltaTime;

        if (Input.IsKeyDown(Key.Left))
            nextPos.X -= speed * deltaTime;

        if (Input.IsKeyDown(Key.Right))
            nextPos.X += speed * deltaTime;

        transform.Position = nextPos;

        if (Input.IsKeyDown(Key.V))
            SetActive(!Enabled);
    }

    internal override void OnActiveStateChange(bool active) {
        Console.WriteLine("CharacterController is now " + (active ? "active" : "inactive"));
    }
}