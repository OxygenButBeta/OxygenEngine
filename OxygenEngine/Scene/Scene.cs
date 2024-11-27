using Newtonsoft.Json;
using OxygenEngine.Serialization;

namespace OxygenEngineCore.Scene;

/// <summary>
/// The Scene entity is used to define a scene in the engine.
/// </summary>
public class Scene : ISerializableEntity {
    public List<WorldObject> worldObjects = new();
    public string Name { get; set; }

    public Scene(string name) {
        Name = name;
    }

    internal void Begin() {
        foreach (var component in worldObjects.SelectMany(worldObject => worldObject.Components))
        {
            component.Value.OnBegin();
        }
    }

    internal void Update(float deltaTime) {
        foreach (var worldObject in worldObjects)
        {
            worldObject.Update(deltaTime);
        }
    }

    public Dictionary<string, string> Serialize() {
        Dictionary<string, string> dict = new();
        dict.Add("Name", Name);
        var worldObjectsDict = new Dictionary<string, string>();
        foreach (var worldObject in worldObjects)
        {
            worldObjectsDict.Add(worldObject.InstanceID.ToString(),
                JsonConvert.SerializeObject(worldObject.Serialize()));
        }

        dict.Add("WorldObjects", JsonConvert.SerializeObject(worldObjectsDict));
        return dict;
    }

    public void Deserialize(Dictionary<string, string> data) {
        Name = data["Name"];
        if (!data.TryGetValue("WorldObjects", out var worldObjectsData))
            return;

        Dictionary<string, string> WorldObjectsDict =
            JsonConvert.DeserializeObject<Dictionary<string, string>>(worldObjectsData);

        foreach (var worldObjectData in WorldObjectsDict)
        {
            var instance = Instantiate();
            instance.Deserialize(JsonConvert.DeserializeObject<Dictionary<string, string>>(worldObjectData.Value));
            worldObjects.Add(instance);
        }
    }

    public WorldObject Instantiate() {
        var instance = new WorldObject();
        worldObjects.Add(instance);
        return instance;
    }
}