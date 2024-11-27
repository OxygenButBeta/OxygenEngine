using Newtonsoft.Json;
using OpenTK.Mathematics;

namespace OxygenEngineCore;

public partial class Spatial : Component {
    public override Dictionary<string, string> Serialize() {
        Dictionary<string, string> dict = new();
        dict.Add("Enabled", Enabled.ToString());
        SerializableVec3 serializablePos = new(Position);
        SerializableQuat serializableRot = new(Rotation);
        SerializableVec3 serializableScale = new(Scale);
        dict.Add("Position", JsonConvert.SerializeObject(serializablePos));
        dict.Add("Rotation", JsonConvert.SerializeObject(serializableRot));
        dict.Add("Scale", JsonConvert.SerializeObject(serializableScale));
        return dict;
    }

    public override void Deserialize(Dictionary<string, string> data) {
        Enabled = bool.Parse(data["Enabled"]);
        m_position = JsonConvert.DeserializeObject<SerializableVec3>(data["Position"]).ToVec3();
        m_rotation = JsonConvert.DeserializeObject<SerializableQuat>(data["Rotation"]).ToQuat();
        m_scale = JsonConvert.DeserializeObject<SerializableVec3>(data["Scale"]).ToVec3();
    }
}