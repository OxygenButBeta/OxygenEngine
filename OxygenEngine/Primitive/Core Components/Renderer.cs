using OpenTK.Mathematics;
using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive.Lib;

public abstract class Renderer : IDisposable, IDrawCallElement {
    protected Texture? texture;
    protected VertexArrayObject Vao;
    protected VertexBufferObject Vertex_VBO;
    protected VertexBufferObject UV_VBO;
    protected IndexBufferObject Index_IBO;


    public Matrix4 ScaleMatrix = Matrix4.Identity;
    public Matrix4 TransformMatrix = Matrix4.Identity;
    public abstract void Render(Shader shader);

    public abstract void Dispose();
    public abstract void PrepareToRender();
    public abstract void DrawCall(Shader shader);
}