using System.Numerics;
using ImGuiNET;
using OxygenEngine.Runtime.Editor.Context_Drawers;
using OxygenEngine.Runtime.Editor.lib;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class Hierarchy : EditorWindow {
    WorldObjectDrawer worldObjectDrawer = new WorldObjectDrawer();

    public override void OnOpen() {
        float panelWidth = 300f;
        float panelHeight = 500f;
        ImGui.SetNextWindowPos(new Vector2(panelWidth, 0), ImGuiCond.Always);
        ImGui.SetNextWindowSize(new Vector2(panelWidth, panelHeight), ImGuiCond.Always);
    }

    protected override void Draw() {
        ImGui.Begin("Hierarchy Panel", ImGuiWindowFlags.NoCollapse);

        foreach (var worldObject in OxygenEngineCore.OxygenEngine.Instance.CurrentScene.worldObjects)
        {
            if (ImGui.Selectable(worldObject.InstanceID.ToString(), false))
            {
                worldObjectDrawer.Target = worldObject;
                Inspector.SelectedContext = worldObjectDrawer;
            }
        }

        ImGui.End();
    }
}