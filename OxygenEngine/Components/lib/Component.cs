using OxygenEngine.Serialization;

namespace OxygenEngineCore;

public abstract class Component : ISerializableEntity {
    public WorldObject worldObject { get; internal set; }

    public void SetActive(bool active) {
        Enabled = active;
        OnActiveStateChange(active);
    }

    [SerializedField] public bool Enabled = true;

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
        //Todo: Not gonna work because i cannot serialize the enabled property
    }

    internal virtual void OnBegin() {
    }

    public abstract Dictionary<string, string> Serialize();

    public abstract void Deserialize(Dictionary<string, string> data);
}