using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngine.Runtime.Runtime;
using OxygenEngineCore.Primitive;
using Vector2 = System.Numerics.Vector2;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class ObjectTransformMenu {
    public static void DrawLeftMenu() {
        ImGui.SetNextWindowPos(new Vector2(0, 30));
        ImGui.SetNextWindowSize(new Vector2(200, ImGui.GetIO().DisplaySize.Y-30));

        if (EngineStarter.engine.OpenGlRenderEngine.DrawCallElements.Count == 0)
        {
            ImGui.LabelText("No object selected", "Please select an object");
            return;
        }

        if (ImGui.Begin("Left Menu", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse))
        {
            ImGui.Text("Instance Transform");
            ImGui.Separator();

            // Her MeshRenderer için ayrı pozisyon düzenleme
            foreach (var drawCallElement in EngineStarter.engine.OpenGlRenderEngine.DrawCallElements)
            {
                var renderer = drawCallElement as MeshRenderer;
                if (renderer == null) continue;
                ImGui.Text("Transform For Object " + renderer.GetHashCode());
                // TransformMatrix'ten pozisyonu al
                Vector3 position = renderer.TransformMatrix.ExtractTranslation();

                // X pozisyonunu güncelle
                if (ImGui.SliderFloat($"X##{renderer.GetHashCode()}", ref position.X, -10.0f, 10.0f))
                {
                }

                // Y pozisyonunu güncelle
                if (ImGui.SliderFloat($"Y##{renderer.GetHashCode()}", ref position.Y, -10.0f, 10.0f))
                {
                }

                // Z pozisyonunu güncelle
                if (ImGui.SliderFloat($"Z##{renderer.GetHashCode()}", ref position.Z, -10.0f, 10.0f))
                {
                    Console.WriteLine($"Object {renderer.GetHashCode()} Z updated: {position.Z}");
                }

                // TransformMatrix'i güncelle
                renderer.TransformMatrix = Matrix4.CreateTranslation(position);

                ImGui.Spacing();
            }

            ImGui.End();
        }
    }
}