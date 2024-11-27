namespace OxygenEngine.Runtime.Editor.lib;

public abstract class EditorWindow {
    public bool IsOpen { get; set; } = true;
    public void DrawWindow() {
        if (IsOpen)
            Draw();
    }

    public abstract void OnOpen();

    protected abstract void Draw();
}