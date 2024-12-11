using System.Reflection;
using OxygenEngine.AssemblyCompiler.Utilities;
using Runtime.Editor.lib;

namespace Runtime.Editor;

public class EditorLoop {
    readonly List<EditorWindow> windows;
 
    public EditorLoop() {
        windows = new List<EditorWindow>();
        foreach (var type in AssemblySearch.FindAllDerivedTypesInAssembly<EditorWindow>(Assembly.GetCallingAssembly()))
            windows.Add((EditorWindow)Activator.CreateInstance(type));
    }

    public void UpdateCallbacks() {
        foreach (var window in windows)
            window.DrawWindow();
    }

    public void OpenWindows() {
        foreach (var window in windows)
            window.OnOpen();
    }
}