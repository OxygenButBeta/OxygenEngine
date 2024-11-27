using Newtonsoft.Json;
using OxygenEngine.Scripting;
using OxygenEngine.Serialization;

namespace OxygenEngineCore;

public abstract class Component : ISerializableEntity {
    public WorldObject worldObject { get; internal set; }

    public bool Enabled {
        get => m_active;
        set {
            if (m_active == value) return;
            m_active = value;
            OnActiveStateChange(value);
        }
    }

    internal bool m_active = true;

    /// <summary>
    /// This method is called when the component is added to the world object.
    /// </summary>
    internal virtual void OnComponentAdded() {
        
    }

    /// <summary>
    /// This method is called every frame.
    /// </summary>
    internal virtual void OnTick(float deltaTime) {
    }

    internal virtual void OnActiveStateChange(bool active) {
    }

    internal virtual void OnBegin() {
        
    }

    public abstract Dictionary<string, string> Serialize();

    public abstract void Deserialize(Dictionary<string, string> data);
}