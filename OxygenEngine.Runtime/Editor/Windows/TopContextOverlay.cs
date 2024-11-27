using System.Numerics;
using ImGuiNET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OxygenEngine.Database.Meta;
using OxygenEngine.Runtime.Editor.lib;
using OxygenEngineCore;
using OxygenEngineCore.Scene;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class TopContextOverlay : EditorWindow {
    public override void OnOpen() {
    }

    protected override void Draw() {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("World Object"))
            {
                if (ImGui.MenuItem("Add New World Object"))
                {
                    OxygenEngineCore.OxygenEngine.Instance.CurrentScene.Instantiate();
                }

                if (ImGui.MenuItem("Save"))
                {
                    Console.WriteLine("Save");
                    var path = MetaUtility.AssetFolderPath() + @"Scenex.json";

                    var x = OxygenEngineCore.OxygenEngine.Instance.CurrentScene.Serialize();
                    File.WriteAllText(path, JsonConvert.SerializeObject(x, Formatting.Indented));
                }

                if (ImGui.MenuItem("Load"))
                {
                    var path = MetaUtility.AssetFolderPath() + @"Scenex.json";
                    var json = File.ReadAllText(path);
                    var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    Scene scene = new Scene("LoadedScene");
                    scene.Deserialize(dic);
                    OxygenEngineCore.OxygenEngine.Instance.CurrentScene = scene;
                }

                ImGui.EndMenu();
            }


            ImGui.EndMainMenuBar();
        }
    }
}