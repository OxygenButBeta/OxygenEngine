using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("O2.Editor")]

namespace OxygenEngineCore;

public partial class WorldObject {
    internal void Update(float deltaTime) {
        Transform.OnTick(deltaTime);
        foreach (var component in Components)
        {
            if (component.Value.Enabled)
                component.Value.OnTick(deltaTime);
        }
    }

    internal void AddComponent<T>() where T : Component {
        var component = Activator.CreateInstance<T>();
        component.worldObject = this;
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
        return Components.GetValueOrDefault(type);
    }

    public WorldObject(string name = "New World Object") {
        Transform = new Transform(this);
        Name = name;
    }
}