using Newtonsoft.Json;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OxygenEngine.Serialization;

namespace OxygenEngineCore.Primitive;

public partial class MeshRenderer : Renderer, IDisposable {
    [SerializedField] Mesh mesh;
    bool m_meshImported;

    public override void Dispose() {
        Vao.Dispose();
        Vertex_VBO.Dispose();
        Index_IBO.Dispose();
        UV_VBO.Dispose();
        texture.Dispose();
    }


    public override void DrawCall(Shader shader) {
        if (!Enabled && m_meshImported)
            return;
        shader.Bind();
        var ScaledTransform = TransformMatrix * ScaleMatrix;
        var offset = GL.GetUniformLocation(shader.ID, "transform");
        GL.UniformMatrix4(offset, true, ref ScaledTransform);

        Vao.Bind();
        GL.DrawElements(BeginMode.Triangles, mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}