using Newtonsoft.Json;
using OxygenEngine.Serialization;
using OxygenEngineCore;

namespace OxygenEngine.Scripting;

public abstract partial class CoreBehaviour : Component {
    protected Spatial spatial => worldObject.spatial;

    internal override void OnComponentAdded() {
        // Begin linking
    }

    public void AddComponent<T>() where T : Component, new() {
        worldObject.AddComponent<T>();
    }

    public void RemoveComponent<T>() where T : Component {
        worldObject.RemoveComponent<T>();
    }

    public T GetComponent<T>(out T component) where T : Component {
        return worldObject.GetComponent<T>(out component);
    }

    public Component GetComponent(Type type) {
        return worldObject.GetComponent(type);
    }

    public WorldObject Instantiate() {
        return OxygenEngineCore.OxygenEngine.Instance.CurrentScene.Instantiate();
    }


}