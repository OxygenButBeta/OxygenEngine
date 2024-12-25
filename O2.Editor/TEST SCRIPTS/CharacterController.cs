using OxygenEngine.Scripting;
using OxygenEngine.Serialization;
using OxygenEngineCore.InputSystem;

namespace Runtime;

public class CharacterController : CoreBehaviour {
    /// Marked as serialized field so it can be edited in the inspector
    [SerializedField]  float speed = 1.0f;

    /// Called every frame by the engine
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
    }

    internal override void OnActiveStateChange(bool active) {
        // Will be called when the Component is enabled or disabled
    }
}