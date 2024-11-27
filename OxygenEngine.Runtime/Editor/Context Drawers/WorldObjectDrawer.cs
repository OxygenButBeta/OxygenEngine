using System.Reflection;
using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngineCore;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngine.Runtime.Editor.Context_Drawers;

public class WorldObjectDrawer : ContextDrawer {
    public WorldObject Target;

    private bool showComponentList = false;
    public override void Draw() {
        ImGui.Text("World Object");
        ImGui.Text("Name: " + Target.Name);
        ImGui.Text("Instance ID: " + Target.InstanceID);
        ImGui.Text("Test");



        Vector3 position = Target.spatial.Position;
        var positionAndSystemNumerics = new System.Numerics.Vector3(position.X, position.Y, position.Z);

        Quaternion rotation = Target.spatial.Rotation;
        var rotationAndSystemNumerics = new System.Numerics.Vector4(rotation.X, rotation.Y, rotation.Z, rotation.W);

        Vector3 scale = Target.spatial.Scale;
        var scaleAndSystemNumerics = new System.Numerics.Vector3(scale.X, scale.Y, scale.Z);

// Position
        ImGui.Text("Position");
        if (ImGui.InputFloat3("Position", ref positionAndSystemNumerics))
        {
            Target.spatial.Position = new Vector3(positionAndSystemNumerics.X, positionAndSystemNumerics.Y, positionAndSystemNumerics.Z);
        }

// Rotation
        ImGui.Text("Rotation");
        if (ImGui.InputFloat4("Rotation", ref rotationAndSystemNumerics))
        {
            // Normalize quaternion if necessary (to maintain valid rotation)
            var updatedQuaternion = new Quaternion(rotationAndSystemNumerics.X, rotationAndSystemNumerics.Y, rotationAndSystemNumerics.Z, rotationAndSystemNumerics.W);
            updatedQuaternion = Quaternion.Normalize(updatedQuaternion);

            Target.spatial.Rotation = updatedQuaternion;
        }

// Scale
        ImGui.Text("Scale");
        if (ImGui.InputFloat3("Scale", ref scaleAndSystemNumerics))
        {
            Target.spatial.Scale = new Vector3(scaleAndSystemNumerics.X, scaleAndSystemNumerics.Y, scaleAndSystemNumerics.Z);
        }
        ImGui.Dummy(new Vector2(0, 20)); 
        if (Target.Components.Count > 0)
        {
            ImGui.Separator();
            ImGui.Text("Components:");
            foreach (var component in Target.Components)
            {
                ImGui.Text(component.Key.Name);
            }
        }
        ImGui.Dummy(new Vector2(0, 30)); 

        if (ImGui.Button("Add Component", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 20)))
        {

            showComponentList = !showComponentList;
        }
        
        if (showComponentList)
        {
            ImGui.BeginChild("Component List", new System.Numerics.Vector2(200, 150));
            
            foreach (var component in ComponentUtility.ComponentTypesInAssembly(Assembly.GetCallingAssembly()))
            {
                if (ImGui.Selectable(component.Name))
                {
                    AddComponent(component);
                }
            }

            ImGui.EndChild();
        }

  

  
    }

    void AddComponent(Type component) {
        Target.AddComponent(component);
    }
}