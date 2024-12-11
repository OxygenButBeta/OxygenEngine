using OpenTK.Mathematics;

namespace OxygenEngineCore;

public partial class Transform {
    internal event Action<Vector3, Vector3> OnPositionChanged;
    internal event Action<Quaternion, Quaternion> OnRotationChanged;
    internal event Action<Vector3, Vector3> OnScaleChanged;
}