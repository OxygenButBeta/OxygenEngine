using System.Numerics;
using ImGuiNET;
using OxygenEngineRuntime.Editor.ContextDrawers;
using Runtime.Editor.lib;

namespace Runtime.Editor.Context_Menu;

public class Hierarchy : EditorWindow {
    WorldObjectDrawer worldObjectDrawer = new WorldObjectDrawer();

    public override void OnOpen() {
        var panelWidth = 300f;
        var panelHeight = 500f;
        ImGui.SetNextWindowPos(new Vector2(panelWidth, 0), ImGuiCond.Always);
        ImGui.SetNextWindowSize(new Vector2(panelWidth, panelHeight), ImGuiCond.Always);
    }

    protected override void Draw() {
        ImGui.Begin("Hierarchy Panel", ImGuiWindowFlags.NoCollapse);

        foreach (var worldObject in OxygenEngineCore.OxygenEngine.Instance.CurrentScene.worldObjects)
        {
            if (ImGui.Selectable(worldObject.InstanceID.ToString()[..6], false))
            {
                worldObjectDrawer.Target = worldObject;
                Inspector.SelectedContext = worldObjectDrawer;
            }
        }

        ImGui.End();
    }
}