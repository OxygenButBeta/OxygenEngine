namespace OxygenEngine.Scripting.lib;

/// <summary>
/// This interface is used to define a component that can be added to  
/// </summary>
public interface IEngineComponent {
    void onBegin();
    void onTick(float deltaTime);
}