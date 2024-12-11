using Newtonsoft.Json;
using OxygenEngine.Serialization;

// ReSharper disable AssignNullToNotNullAttribute

namespace OxygenEngineCore;

[Serializable]
public partial class WorldObject : ISerializableEntity {
    public Dictionary<string, string> Serialize() {
        var dict = new Dictionary<string, string>
        {
            { "InstanceID", InstanceID.ToString() },
            { "IsStatic", IsStatic.ToString() },
            { "spatial", JsonConvert.SerializeObject(Transform.Serialize()) }
        };

        var componentDict = new Dictionary<string, string>();
        foreach (var keyValuePair in Components)
        {
            var typeName = keyValuePair.Key.FullName;
            var serializedResult = keyValuePair.Value.Serialize();
            componentDict.Add(typeName, JsonConvert.SerializeObject(serializedResult,Formatting.Indented));
        }

        dict.Add("Components", JsonConvert.SerializeObject(componentDict));
        return dict;
    }

    public void Deserialize(Dictionary<string, string> data) {
        //  InstanceID = int.Parse(data["InstanceID"]);
        IsStatic = bool.Parse(data["IsStatic"]);
        Transform = new Transform(this);
        Transform.Deserialize(JsonConvert.DeserializeObject<Dictionary<string, string>>(data["spatial"]));

        var componentDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data["Components"]);
        foreach (var keyValuePair in componentDict)
        {
            var componentType = Type.GetType(keyValuePair.Key);
            if (componentType is null)
            {
                continue;
            }
            var instance = Activator.CreateInstance(componentType);
            if (instance is not Component component)
                continue;
            component.worldObject = this;
            component.Deserialize(JsonConvert.DeserializeObject<Dictionary<string, string>>(keyValuePair.Value));
            Components.Add(componentType, component);
        }
    }
}