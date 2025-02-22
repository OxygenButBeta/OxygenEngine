﻿using Newtonsoft.Json;
using OxygenEngine.Serialization;

namespace OxygenEngineCore.Scene;

/// <summary>
/// The Scene entity is used to define a scene in the engine.
/// </summary>
public class Scene(string name) : ISerializableEntity {
    public readonly List<WorldObject> worldObjects = new();
    string Name { get; set; } = name;

    internal void Begin() {
        foreach (var component in worldObjects.SelectMany(worldObject => worldObject.Components))
            component.Value.OnBegin();
    }

    internal void Update(float deltaTime) {
        foreach (var worldObject in worldObjects)
            worldObject.Update(deltaTime);
    }

    public Dictionary<string, string> Serialize() {
        Dictionary<string, string> dict = new() { { "Name", Name } };
        var worldObjectsDict = worldObjects.ToDictionary(worldObject => worldObject.InstanceID.ToString(),
            worldObject => JsonConvert.SerializeObject(worldObject.Serialize()));

        dict.Add("WorldObjects", JsonConvert.SerializeObject(worldObjectsDict));
        return dict;
    }

    public void Deserialize(Dictionary<string, string> data) {
        Name = data["Name"];
        if (!data.TryGetValue("WorldObjects", out var worldObjectsData))
            return;

        var WorldObjectsDict =
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