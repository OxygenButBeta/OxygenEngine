using OpenTK.Mathematics;
using OxygenEngine.Scripting;
using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive.Lib;

public abstract class Renderer : CoreBehaviour, IDrawCallElement {
    protected Texture? texture;
    public VertexArrayObject Vao { get; protected set; }
    protected VertexBufferObject Vertex_VBO;
    protected VertexBufferObject UV_VBO;
    protected IndexBufferObject Index_IBO;


    protected Matrix4 ScaleMatrix = Matrix4.Identity;
    protected Matrix4 RotationMatrix = Matrix4.Identity;
    protected Matrix4 TransformMatrix = Matrix4.Identity;

    public abstract void Dispose();
    public abstract void DrawCall(Shader shader);
}