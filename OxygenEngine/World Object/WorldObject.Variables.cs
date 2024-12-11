namespace OxygenEngineCore;

public partial class WorldObject {
    public readonly Guid InstanceID = Guid.NewGuid();
    public bool IsStatic { get; set; } = false;
    public Transform Transform { get; internal set; }
    public string Name { get; set; }
    internal Dictionary<Type, Component> Components = new();
}