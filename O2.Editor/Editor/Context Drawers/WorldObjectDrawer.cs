using System.Reflection;
using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngineCore;
using OxygenEngineRuntime.Editor.ContextDrawers.Contexts;
using OxygenEngineRuntime.Editor.ContextDrawers.Pre_Denifed_Drawers;
using Runtime.Editor;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngineRuntime.Editor.ContextDrawers;

public class WorldObjectDrawer : ContextDrawer {
    public WorldObject Target;

    bool showComponentList = false;

    public override void Draw() {
        ImGui.Dummy(new Vector2(0, 5));
        ImGui.Text("World Object");

        var tname = Target.Name;
        var io = ImGui.GetIO();
        io.AddInputCharacter(3);
        if (ImGui.InputText(Target.Name, ref tname, 100))
            Target.Name = tname;

        ImGui.Text("Instance ID: " + Target.InstanceID);
        SpatialContextDrawer.Draw(Target.spatial);


        ImGui.Dummy(new Vector2(0, 20));
        if (Target.Components.Count > 0)
        {
            ImGui.Separator();
            foreach (var component in Target.Components)
            {
                ImGui.Text(component.Key.Name);
                CoreBehaviourContextDrawer.Draw(component.Value);
            }
        }

        ImGui.Dummy(new Vector2(0, 30));

        if (ImGui.Button("Add Component", new Vector2(ImGui.GetContentRegionAvail().X, 20)))
        {
            showComponentList = !showComponentList;
        }

        if (!showComponentList)
            return;

        ImGui.BeginChild("Component List", new Vector2(200, 150));

        foreach (var component in ComponentUtility.ComponentTypesInAssembly(Assembly.GetCallingAssembly()))
        {
            if (Target.GetComponent(typeof(Component)) != null)
            {
                continue;
            }
            if (ImGui.Selectable(component.Name))
            {
                AddComponent(component);
            }
        }

        ImGui.EndChild();
    }

    void AddComponent(Type component) {
        Target.AddComponent(component);
    }
}