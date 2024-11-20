using Assimp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OxygenEngine.Shaders;
using OxygenEngineCore.Rendering;
using OxygenEngineCore.Rendering.Shading;

namespace OxygenEngineCore.Primitive;

public class Mesh {
    public Matrix4 ScaleMatrix = Matrix4.Identity;
    public Matrix4 TransformMatrix;
    public Vector3[] Vertices { get; private set; }
    public Vector3[] Normals { get; private set; }
    public Vector2[] UVs { get; private set; }
    public uint[] Indices { get; private set; }

    readonly string path;
    readonly string texturePath;
    Texture? texture;
    VertexArrayObject Vao;
    VertexBufferObject Vertex_VBO;
    VertexBufferObject UV_VBO;
    IndexBufferObject Index_IBO;

    public Mesh(string path, string texturePath = "default.png") {
        this.path = path;
        this.texturePath = texturePath;
    }

    public void ImportMesh() {
        var mesh = new AssimpContext().ImportFile(path).Meshes[0];

        Vertices = mesh.Vertices.Select(v => new Vector3(v.X, v.Y, v.Z)).ToArray();
        Normals = mesh.Normals.Select(n => new Vector3(n.X, n.Y, n.Z)).ToArray();
        UVs = mesh.TextureCoordinateChannels[0].Select(t => new Vector2(t.X, t.Y)).ToArray();
        Indices = mesh.GetUnsignedIndices();

        TransformMatrix = Matrix4.Identity;

        Vao = new VertexArrayObject();
        Vao.Bind();

        Vertex_VBO = new VertexBufferObject(Vertices);
        Vertex_VBO.BindBuffer();
        Vao.BindVertexArray(0, 3, Vertex_VBO);

        UV_VBO = new VertexBufferObject(UVs);
        UV_VBO.BindBuffer();
        Vao.BindVertexArray(1, 2, UV_VBO);

        Index_IBO = new IndexBufferObject(Indices);


        texture = new Texture(texturePath);
    }


    public void Render(Shader shader) {
        shader.Bind();
        var ScaledTransform = TransformMatrix * ScaleMatrix;
        var offset = GL.GetUniformLocation(shader.ID, "transform");
        GL.UniformMatrix4(offset, true, ref ScaledTransform);

        Vao.Bind();
        Index_IBO.BindBuffer();
        texture.Bind();

        GL.DrawElements(BeginMode.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
    }


    public void Dispose() {
        Vao.Dispose();
        Vertex_VBO.Dispose();
        Index_IBO.Dispose();
        UV_VBO.Dispose();
        texture.Dispose();
    }
}