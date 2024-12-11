using System.Diagnostics;
using System.Reflection;
using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngine.Serialization;
using OxygenEngineCore;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineRuntime.Editor.ContextDrawers.Pre_Denifed_Drawers;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8605 // Unboxing a possibly null value.

#pragma warning disable CS8604 // Possible null reference argument.

namespace OxygenEngineRuntime.Editor.ContextDrawers.Contexts;

public class CoreBehaviourContextDrawer {
    public static void Draw(Component component) {
        if (component.GetType() == typeof(Transform))
        {
            SpatialContextDrawer.Draw(component as Transform);
            return;
        }

        if (component.GetType() == typeof(MeshRenderer))
        {
            (component as MeshRenderer).Draw();
 
        }

        foreach (var serializedVariable in SerializedFieldAttribute.GetAllSerializedVariables(component))
        {
            var type = serializedVariable.FieldType;
            if (type == typeof(Vector3))
            {
                serializedVariable.SetValue(component,
                    Vector3ContextDrawer.Draw((Vector3)serializedVariable.GetValue(component),
                        serializedVariable.Name));
            }

            if (type == typeof(Mesh))
            {
                MeshContextDrawer.Draw((Mesh)serializedVariable.GetValue(component));
            }

            if (type == typeof(Quaternion))
            {
                serializedVariable.SetValue(component,
                    QuaternionContextDrawer.Draw((Quaternion)serializedVariable.GetValue(component),
                        serializedVariable.Name));
            }


            if (type == typeof(string))
            {
                ImGui.Text(serializedVariable.Name);
                string value = (string)serializedVariable.GetValue(component);
                if (value == null)
                    value = "";
                if (ImGui.InputText(serializedVariable.Name, ref value, 100))
                    serializedVariable.SetValue(component, value);
            }

            if (type == typeof(float))
            {
                ImGui.Text(serializedVariable.Name);
                float value = (float)serializedVariable.GetValue(component);
                if (ImGui.InputFloat(serializedVariable.Name, ref value))
                    serializedVariable.SetValue(component, value);
            }

            if (type == typeof(int))
            {
                ImGui.Text(serializedVariable.Name);
                int value = (int)serializedVariable.GetValue(component);
                if (ImGui.InputInt(serializedVariable.Name, ref value))
                    serializedVariable.SetValue(component, value);
            }

            if (type == typeof(bool))
            {
                ImGui.Text(serializedVariable.Name);
                bool value = (bool)serializedVariable.GetValue(component);
                ImGui.Checkbox(serializedVariable.Name, ref value);
                serializedVariable.SetValue(component, value);
            }
        }
    }
}