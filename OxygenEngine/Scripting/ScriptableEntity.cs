using Newtonsoft.Json;
using OxygenEngine.Serialization;
using OxygenEngineCore;

namespace OxygenEngine.Scripting;

public abstract partial class CoreBehaviour : Component {
    protected Transform Transform => worldObject.Transform;

    internal override void OnComponentAdded() {
        // Begin linking
    }

    public void AddComponent<T>() where T : Component {
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
    public T GetComponent<T>() where T : Component {
        return(T) worldObject.GetComponent(typeof(T));
    }

    public WorldObject Instantiate() {
        return OxygenEngineCore.OxygenEngine.Instance.CurrentScene.Instantiate();
    }
}