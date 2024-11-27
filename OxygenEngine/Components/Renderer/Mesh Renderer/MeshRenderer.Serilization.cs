using Newtonsoft.Json;
using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive;

public partial class MeshRenderer {
    public override Dictionary<string, string> Serialize() {
        Dictionary<string, string> dict = new();
        dict.Add("Mesh", JsonConvert.SerializeObject(mesh.Serialize()));
        dict.Add("Texture", JsonConvert.SerializeObject(texture.Serialize()));
        return dict;
    }

    public override void Deserialize(Dictionary<string, string> data) {
        mesh = new Mesh();
        mesh.Deserialize(JsonConvert.DeserializeObject<Dictionary<string, string>>(data["Mesh"]));
        texture = new Texture();
        texture.Deserialize(JsonConvert.DeserializeObject<Dictionary<string, string>>(data["Texture"]));
    }
}