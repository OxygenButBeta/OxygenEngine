namespace Runtime.Editor.lib;

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