using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OxygenEngine.Runtime")]

namespace OxygenEngineCore;

public partial class WorldObject {
    internal void Update(float deltaTime) {
        spatial.OnTick(deltaTime);
        foreach (var component in Components)
        {
            if (component.Value.Enabled)
                component.Value.OnTick(deltaTime);
        }
    }

    internal void AddComponent<T>() where T : Component, new() {
        var component = new T
        {
            worldObject = this
        };
        Components.Add(typeof(T), component);
        component.OnComponentAdded();
    }

    internal void AddComponent(Type type) {
        var component = (Component)Activator.CreateInstance(type);
        component.worldObject = this;
        Components.Add(type, component);
        component.OnComponentAdded();
        component.OnBegin();
    }

    internal void RemoveComponent<T>() where T : Component {
        Components.Remove(typeof(T));
    }

    internal T GetComponent<T>(out T component) where T : Component {
        component = (T)Components[typeof(T)];
        return (T)Components[typeof(T)];
    }

    internal Component GetComponent(Type type) {
        return Components[type];
    }

    public WorldObject() {
        spatial = new Spatial(this);
    }
}