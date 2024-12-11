using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngineCore;
using OxygenEngineRuntime.Editor.ContextDrawers.Contexts;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Pre_Denifed_Drawers;

internal static class SpatialContextDrawer {
    public static void Draw(Transform transform) {
        transform.Position = Vector3ContextDrawer.Draw(transform.Position, "Position",transform.GetHashCode());
        transform.Rotation = QuaternionContextDrawer.Draw(transform.Rotation, "Rotation");
        transform.Scale = Vector3ContextDrawer.Draw(transform.Scale, "Scale");

        ImGui.Dummy(new Vector2(0, 20));
        if (ImGui.Button("Reset Transform"))
        {
            transform.Position = Vector3.Zero;
            transform.Scale = Vector3.One;
            transform.Rotation = Quaternion.Identity;
        }
    }
}