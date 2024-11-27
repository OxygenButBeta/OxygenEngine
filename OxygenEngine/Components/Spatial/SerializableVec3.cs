using OpenTK.Mathematics;

namespace OxygenEngineCore;
[System.Serializable]

public class SerializableVec3(Vector3 vec3) {
    public float x = vec3.X;
    public float y = vec3.Y;
    public float z = vec3.Z;

    public Vector3 ToVec3() {
        return new Vector3(x, y, z);
    }
}
[System.Serializable]
public class SerializableQuat(Quaternion quat) {
    public float x = quat.X;
    public float y = quat.Y;
    public float z = quat.Z;
    public float w = quat.W;

    public Quaternion ToQuat() {
        return new Quaternion(x, y, z, w);
    }
}