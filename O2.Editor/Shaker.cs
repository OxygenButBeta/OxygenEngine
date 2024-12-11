using OpenTK.Mathematics;
using OxygenEngine.Scripting;
using OxygenEngine.Serialization;

namespace Runtime;

public class Shaker : CoreBehaviour {
    [SerializedField] private float ShakeDuration = 0.0f;
    Random Random = new Random();

    internal override void OnTick(float deltaTime) {
        float     _shakeDuration = ShakeDuration;
        if (_shakeDuration > 0.0f) {
            _shakeDuration -= deltaTime;
            if (_shakeDuration <= 0.0f) {
                _shakeDuration = 0.0f;
                Transform.Position = Vector3.Zero;
            } else {
                Transform.Position = new Vector3(
                    (float) Random.NextDouble() * ShakeDuration - 1.0f,
                    (float) Random.NextDouble() * ShakeDuration - 1.0f,
                    (float) Random.NextDouble() * ShakeDuration - 1.0f
                );
            }
        }
    }
}