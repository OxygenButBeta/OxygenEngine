namespace Runtime.Editor.lib;


/// <summary>
/// Devired classes will be used as windows in the editor
/// No Need to instantiate derived classes
/// The editor will handle the instantiation at runtime
/// </summary>
public abstract class EditorWindow {
    public bool IsOpen { get; set; } = true;

    public void DrawWindow() {
        if (IsOpen)
            Draw();
    }


    /// <summary>
    /// This method will be called when the window is opened
    /// </summary>
    public abstract void OnOpen();

    /// <summary>
    /// This method will be called every frame to draw the window
    /// </summary>
    protected abstract void Draw();
}