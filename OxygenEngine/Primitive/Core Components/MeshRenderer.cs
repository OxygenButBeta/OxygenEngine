using OpenTK.Mathematics;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;
using OpenTK.Graphics.OpenGL;

namespace OxygenEngineCore.Primitive;

public class MeshRenderer : Renderer, IDisposable {
    internal Mesh mesh;
    public bool IsStatic { get; set; } = false;

    public MeshRenderer(Mesh mesh, Texture texture) {
        this.mesh = mesh;
        this.texture = texture;
    }

    public override void Render(Shader shader) {
    }

    public override void Dispose() {
        Vao.Dispose();
        Vertex_VBO.Dispose();
        Index_IBO.Dispose();
        UV_VBO.Dispose();
        texture.Dispose();
    }

    bool m_dataCopiedToGPU = false;
    bool m_dataCopyPending = false;

    public override void PrepareToRender() {
        Console.WriteLine("Preparing to render");
        mesh = mesh.ImportAsset();

        Vao = new VertexArrayObject();
        Vao.Bind();

        Vertex_VBO = new VertexBufferObject(mesh.Vertices);
        Vertex_VBO.BindBuffer();
        Vao.BindVertexArray(0, 3, Vertex_VBO);

        UV_VBO = new VertexBufferObject(mesh.UVs);
        UV_VBO.BindBuffer();
        Vao.BindVertexArray(1, 2, UV_VBO);

        Index_IBO = new IndexBufferObject(mesh.Indices);

        Vao.Bind();
        Index_IBO.BindBuffer();
        texture.Bind();
        m_dataCopiedToGPU = true;
        m_dataCopyPending = false;
    }

    public override void DrawCall(Shader shader) {
        if (!m_dataCopiedToGPU && !m_dataCopyPending)
        {
            Console.WriteLine("Pending data to copy..");
            PrepareToRender();
            shader.Bind();
            return;
        }

        var ScaledTransform = TransformMatrix * ScaleMatrix;
        var offset = GL.GetUniformLocation(shader.ID, "transform");
        GL.UniformMatrix4(offset, true, ref ScaledTransform);
        GL.DrawElements(BeginMode.Triangles, mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}