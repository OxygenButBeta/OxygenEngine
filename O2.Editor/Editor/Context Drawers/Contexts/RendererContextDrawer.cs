using System.Numerics;
using ImGuiNET;
using OxygenEngine.AssetDatabase;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Contexts;

public static class RendererContextDrawer {
    static bool selectMat;

    public static void Draw(this MeshRenderer renderer) {
        if (renderer is null)
            return;

        if (ImGui.Button("Select Texture", new Vector2(ImGui.GetContentRegionAvail().X, 20)))
            selectMat = !selectMat;

        ImGui.BeginChild("Texture List", new Vector2(200, 150));

        foreach (var objMeta in AssetDatabase.IndexedAssets)
        {
            if (objMeta.FileExtension != ".jpg")
                continue;

            if (ImGui.Selectable(objMeta.FileName))
            {
                Console.WriteLine("Selected Texture: " + objMeta.FileName);
                renderer.texture.Dispose();
                renderer.texture = new Texture
                {
                    textureMetaGuid = objMeta.FileGuid
                };
                renderer.texture.ImportAsset();
                renderer.PrepareToRender();
            }
        }

        ImGui.EndChild();
        ImGui.Dummy(new(0, 20));
    }
}