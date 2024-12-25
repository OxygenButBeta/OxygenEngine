using System.Text;
using ImGuiNET;
using Runtime.Editor.lib;

namespace Runtime.Editor.Context_Menu {
    public class DebugConsole : EditorWindow {
        static readonly List<string?> Logs = new();

        public override void OnOpen() => Console.SetOut(new ConsoleLogger());

        protected override void Draw() {
            ImGui.Text("Debug Console");
            ImGui.Separator();

            ImGui.BeginChild("LogArea", new System.Numerics.Vector2(0, -30));
            foreach (var log in Logs)
                ImGui.TextWrapped(log);

            ImGui.EndChild();

            ImGui.SameLine();
            if (ImGui.Button("Clear"))
                Logs.Clear();
        }


        class ConsoleLogger : TextWriter {
            public override Encoding Encoding => Encoding.UTF8;
            public override void WriteLine(string? value) => Logs.Add(value);
            public override void Write(string? value) {
                if (!string.IsNullOrEmpty(value))
                    Logs.Add(value);
            }
        }
    }
}