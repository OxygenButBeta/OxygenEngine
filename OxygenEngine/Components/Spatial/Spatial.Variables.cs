using OpenTK.Mathematics;

namespace OxygenEngineCore;

public partial class Spatial {
    public Vector3 Position {
        get => m_position;
        set => HandlePos(value);
    }

    public Quaternion Rotation {
        get => m_rotation;
        set => HandleRot(value);
    }

    public Vector3 Scale {
        get => m_scale;
        set => HandleScale(value);
    }


    public Spatial parent;
    public Spatial[] children;
    internal Matrix4 TransformMatrix => Matrix4.CreateTranslation(m_position);
    internal Matrix4 ScaleMatrix => Matrix4.CreateScale(m_scale);
    internal Matrix4 RotationMatrix => Matrix4.CreateFromQuaternion(m_rotation);

    Vector3 m_position;
    Quaternion m_rotation;
    Vector3 m_scale;
}