using System.Numerics;
using ImGuiNET;
using OxygenEngine.Runtime.Runtime;
using OxygenEngineCore.Primitive;

namespace OxygenEngine.Runtime.Editor.Context_Menu;

public class TopContextOverlay {
    public static void DrawTopContextMenu() {
        ImGui.SetNextWindowPos(new Vector2(0, 0));
        ImGui.SetNextWindowSize(new Vector2(ImGui.GetIO().DisplaySize.X, 30));

        if (ImGui.Begin("TopContextMenu",
                ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar))
        {
            // Import Cat Menüsü
            if (ImGui.BeginMenu("Import Cat"))
            {
                foreach (var asset in AssetDatabase.AssetDatabase.IndexedAssets)
                {
                    if (asset.FileExtension != ".obj")
                    {
                        continue;
                    }

                    if (ImGui.MenuItem(asset.FileName))
                    {
                        var mesh = new Mesh(asset.FileGuid);
                        MeshRenderer meshRenderer = new(mesh, new(@"261fb487-1c2b-47ab-8b5b-f86d3710a7c2"));
                        EngineStarter.engine.AttachToRenderQueue(meshRenderer);
                    }
                }
                ImGui.EndMenu();
            }

            ImGui.SameLine();
            if (ImGui.Button("Edit"))
            {
                Console.WriteLine("Edit clicked");
            }

            ImGui.SameLine();
            if (ImGui.Button("View"))
            {
                Console.WriteLine("View clicked");
            }

            ImGui.End();
        }
    }
}