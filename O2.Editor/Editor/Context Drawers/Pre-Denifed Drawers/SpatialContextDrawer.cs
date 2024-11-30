using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngineCore;
using OxygenEngineRuntime.Editor.ContextDrawers.Contexts;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Pre_Denifed_Drawers;

internal static class SpatialContextDrawer {
    public static void Draw(Spatial spatial) {
        spatial.Position = Vector3ContextDrawer.Draw(spatial.Position, "Position",spatial.GetHashCode());
        spatial.Rotation = QuaternionContextDrawer.Draw(spatial.Rotation, "Rotation");
        spatial.Scale = Vector3ContextDrawer.Draw(spatial.Scale, "Scale");

        ImGui.Dummy(new Vector2(0, 20));
        if (ImGui.Button("Reset Transform"))
        {
            spatial.Position = Vector3.Zero;
            spatial.Scale = Vector3.One;
            spatial.Rotation = Quaternion.Identity;
        }
    }
}