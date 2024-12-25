using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngineCore;
using OxygenEngineRuntime.Editor.ContextDrawers.Contexts;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngineRuntime.Editor.ContextDrawers.PreDefinedDrawers;

internal static class SpatialContextDrawer {
    public static void Draw( ref Transform transform) {
        transform.Position = Vector3ContextDrawer.Draw(transform.Position, "Position",transform.GetHashCode());
        transform.Rotation = QuaternionContextDrawer.Draw(transform.Rotation, "Rotation");
        transform.Scale = Vector3ContextDrawer.Draw(transform.Scale, "Scale");
    }
}