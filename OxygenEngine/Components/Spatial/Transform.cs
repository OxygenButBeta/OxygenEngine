using OpenTK.Mathematics;

namespace OxygenEngineCore;

public partial class Transform : Component {
    void HandleScale(Vector3 value) {
        m_scale = value;
        OnScaleChanged?.Invoke(m_scale, value);
    }

    void HandleRot(Quaternion value) {
        m_rotation = value;
        OnRotationChanged?.Invoke(m_rotation, value);
    }

    void HandlePos(Vector3 value) {
        m_position = value;
        OnPositionChanged?.Invoke(m_position, value);
    }

    public Transform(WorldObject worldObject) {
        m_position = Vector3.Zero;
        m_rotation = Quaternion.Identity;
        m_scale = Vector3.One;
        this.worldObject = worldObject;
    }

    public Vector3 Forward => Vector3.Transform(Vector3.UnitZ, m_rotation);
}