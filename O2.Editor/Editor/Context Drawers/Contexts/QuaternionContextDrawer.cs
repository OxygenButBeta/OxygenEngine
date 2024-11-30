using ImGuiNET;
using OpenTK.Mathematics;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Contexts;

public static class QuaternionContextDrawer {
    public static Quaternion Draw(Quaternion q, string label) {
        var QAndSystemNumerics = new System.Numerics.Vector4(q.X, q.Y, q.Z,q.W);

        ImGui.Text(label);
        if (ImGui.InputFloat4(label, ref QAndSystemNumerics))
        {
            q = new Quaternion(QAndSystemNumerics.X, QAndSystemNumerics.Y,
                QAndSystemNumerics.Z,q.W);
        }

        return q;
    }
}