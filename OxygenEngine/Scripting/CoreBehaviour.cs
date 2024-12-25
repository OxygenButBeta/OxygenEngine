using OxygenEngineCore;

namespace OxygenEngine.Scripting;

public abstract partial class CoreBehaviour : Component {
    protected Transform transform => worldObject.Transform;

    internal override void OnComponentAdded() {
        //TODO: Begin linking
    }
    public void AddComponent<T>() where T : Component => worldObject.AddComponent<T>();
    public void RemoveComponent<T>() where T : Component => worldObject.RemoveComponent<T>();
    public T GetComponent<T>(out T component) where T : Component => worldObject.GetComponent<T>(out component);
    public Component GetComponent(Type type) => worldObject.GetComponent(type);
    public T GetComponent<T>() where T : Component => (T) worldObject.GetComponent(typeof(T));
    public WorldObject Instantiate() => OxygenEngineCore.OxygenEngine.Instance.CurrentScene.Instantiate();
}