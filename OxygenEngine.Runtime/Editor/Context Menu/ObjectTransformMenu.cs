using ImGuiNET;
using OpenTK.Mathematics;
using OxygenEngine.Runtime.Runtime;
using OxygenEngineCore.Primitive;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class ObjectTransformMenu {
    public static void DrawLeftMenu() {
        ImGui.SetNextWindowPos(new Vector2(0, 30));
        ImGui.SetNextWindowSize(new Vector2(200, ImGui.GetIO().DisplaySize.Y - 30));

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

    public static void DrawUIClr() {
        ImGuiStylePtr style = ImGui.GetStyle();
        var isDarkStyle = true;
        var alpha = .4f;
        // Light style colors
        style.Alpha = 1.0f;
        style.FrameRounding = 3.0f;
        style.Colors[(int)ImGuiCol.Text] = new Vector4(0.00f, 0.00f, 0.00f, 1.00f);
        style.Colors[(int)ImGuiCol.TextDisabled] = new Vector4(0.60f, 0.60f, 0.60f, 1.00f);
        style.Colors[(int)ImGuiCol.WindowBg] = new Vector4(0.94f, 0.94f, 0.94f, 0.94f);
        style.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
        style.Colors[(int)ImGuiCol.PopupBg] = new Vector4(1.00f, 1.00f, 1.00f, 0.94f);
        style.Colors[(int)ImGuiCol.Border] = new Vector4(0.00f, 0.00f, 0.00f, 0.39f);
        style.Colors[(int)ImGuiCol.BorderShadow] = new Vector4(1.00f, 1.00f, 1.00f, 0.10f);
        style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(1.00f, 1.00f, 1.00f, 0.94f);
        style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.26f, 0.59f, 0.98f, 0.40f);
        style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.26f, 0.59f, 0.98f, 0.67f);
        style.Colors[(int)ImGuiCol.TitleBg] = new Vector4(0.96f, 0.96f, 0.96f, 1.00f);
        style.Colors[(int)ImGuiCol.TitleBgCollapsed] = new Vector4(1.00f, 1.00f, 1.00f, 0.51f);
        style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.82f, 0.82f, 0.82f, 1.00f);
        style.Colors[(int)ImGuiCol.MenuBarBg] = new Vector4(0.86f, 0.86f, 0.86f, 1.00f);
        style.Colors[(int)ImGuiCol.ScrollbarBg] = new Vector4(0.98f, 0.98f, 0.98f, 0.53f);
        style.Colors[(int)ImGuiCol.ScrollbarGrab] = new Vector4(0.69f, 0.69f, 0.69f, 1.00f);
        style.Colors[(int)ImGuiCol.ScrollbarGrabHovered] = new Vector4(0.59f, 0.59f, 0.59f, 1.00f);
        style.Colors[(int)ImGuiCol.ScrollbarGrabActive] = new Vector4(0.49f, 0.49f, 0.49f, 1.00f);
        style.Colors[(int)ImGuiCol.CheckMark] = new Vector4(0.26f, 0.59f, 0.98f, 1.00f);
        style.Colors[(int)ImGuiCol.SliderGrab] = new Vector4(0.24f, 0.52f, 0.88f, 1.00f);
        style.Colors[(int)ImGuiCol.SliderGrabActive] = new Vector4(0.26f, 0.59f, 0.98f, 1.00f);
        style.Colors[(int)ImGuiCol.Button] = new Vector4(0.26f, 0.59f, 0.98f, 0.40f);
        style.Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.26f, 0.59f, 0.98f, 1.00f);
        style.Colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.06f, 0.53f, 0.98f, 1.00f);

        if (isDarkStyle)
        {
            for (int i = 0; i < (int)ImGuiCol.COUNT; i++)
            {
                Vector4 color = style.Colors[i];
                float h, s, v;
                ImGui.ColorConvertRGBtoHSV(color.X, color.Y, color.Z, out h, out s, out v);

                if (s < 0.1f)
                {
                    v = 1.0f - v;
                }

                ImGui.ColorConvertHSVtoRGB(h, s, v, out color.X, out color.Y, out color.Z);

                if (color.W < 1.0f)
                {
                    color.W *= alpha;
                }

                style.Colors[i] = color;
            }
        }
        else
        {
            for (int i = 0; i < (int)ImGuiCol.COUNT; i++)
            {
                Vector4 color = style.Colors[i];
                if (color.W < 1.0f)
                {
                    color *= alpha;
                }

                style.Colors[i] = color;
            }
        }
    }
}