using System.Numerics;
using ImGuiNET;
using OxygenEngine.AssetDatabase;
using OxygenEngineCore.Primitive;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Contexts;

public static class MeshContextDrawer {
    static bool selectMesh;

    public static void Draw(this Mesh mesh) {
        ImGui.Text("Vertices Count");
        ImGui.Text(mesh.Vertices.Length.ToString());

        if (ImGui.Button("Select Mesh", new Vector2(ImGui.GetContentRegionAvail().X, 20)))
            selectMesh = !selectMesh;

        if (!selectMesh)
        {
            return;
        }
        
        ImGui.BeginChild("Mesh List", new Vector2(200, 150));

        foreach (var objMeta in AssetDatabase.IndexedAssets)
        {
            if (objMeta.FileExtension != ".obj")
                continue;

            if (ImGui.Selectable(objMeta.FileName))
            {
                mesh.ModelMetaGuid = objMeta.FileGuid;
                mesh.ImportAsset();
                mesh.renderer.PrepareToRender();
            }
        }

        ImGui.EndChild();

        ImGui.Dummy(new(0, 20));
       

    }
}