using System.Numerics;
using ImGuiNET;
using OxygenEngine.Runtime.Editor.lib;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class Inspector : EditorWindow {
    public static ContextDrawer SelectedContext;

    public override void OnOpen() {
        float panelWidth = 300f;
        float panelHeight = 1080f;

        ImGui.SetNextWindowPos(new Vector2(ImGui.GetIO().DisplaySize.X - panelWidth, 0), ImGuiCond.Always);
        ImGui.SetNextWindowSize(new Vector2(panelWidth, panelHeight), ImGuiCond.Always);
    }

    protected override void Draw() {
        ImGui.Begin("Inspector Panel");
        if (SelectedContext == null)
            ImGui.Text("No object selected");
        else
            SelectedContext.Draw();
        ImGui.End();
    }
}