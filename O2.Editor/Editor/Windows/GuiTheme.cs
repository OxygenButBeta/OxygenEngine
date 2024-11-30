using System.Numerics;
using ImGuiNET;
using Runtime.Editor.lib;

namespace OxygenEngineRuntime.Editor.Context_Menu;

public class GuiTheme : EditorWindow {
    public override void OnOpen() {
        var style = ImGui.GetStyle();
        const bool isDarkStyle = true;
        const float alpha = .4f;
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
                var color = style.Colors[i];
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

    protected override void Draw() {
    }
}