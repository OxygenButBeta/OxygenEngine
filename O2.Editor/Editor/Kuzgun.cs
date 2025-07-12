using OxygenEngine.Scripting;
using OxygenEngine.Serialization;

public class Kuzgun : CoreBehaviour {
    [SerializedField] public string name = "Kuzgun";
    [SerializedField] float maxScale = 1.0f;
    [SerializedField] float minScale = 0.1f;
    [SerializedField] float scaleSpeed = 0.1f;

    float elapsedTime = 0.0f;

    internal override void OnTick(float deltaTime) {
        elapsedTime += deltaTime;
        float scale = minScale + (maxScale - minScale) * (MathF.Sin(elapsedTime * scaleSpeed) + 1) / 2;

        transform.Scale = new OpenTK.Mathematics.Vector3(transform.Scale.X, scale, transform.Scale.Z);
    }
}