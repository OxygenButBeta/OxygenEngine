using Assimp;
using OpenTK.Mathematics;
using OxygenEngine.AssetDatabase;
using OxygenEngine.Database.Meta;
using OxygenEngineCore.Primitive.Lib;

namespace OxygenEngineCore.Primitive;

public class Mesh : IAssetImporter<Mesh> {
    public Vector3[] Vertices { get; private set; }
    public Vector3[] Normals { get; private set; }
    public Vector2[] UVs { get; private set; }
    public uint[] Indices { get; private set; }
    readonly string KeyGuid;

    public Mesh(string KeyGuid) {
        this.KeyGuid = KeyGuid;
    }

    public Mesh ImportAsset() {

        var mesh = new AssimpContext().ImportFile((AssetDatabase.GuidToMetaData(KeyGuid).GetExactPathFromMeta()))
            .Meshes[0];

        Vertices = mesh.Vertices.Select(v => new Vector3(v.X, v.Y, v.Z)).ToArray();
        Normals = mesh.Normals.Select(n => new Vector3(n.X, n.Y, n.Z)).ToArray();
        UVs = mesh.TextureCoordinateChannels[0].Select(t => new Vector2(t.X, t.Y)).ToArray();
        Indices = mesh.GetUnsignedIndices();
        return this;
    }
}