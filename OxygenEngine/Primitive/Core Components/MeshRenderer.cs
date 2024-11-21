using OpenTK.Mathematics;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;
using OpenTK.Graphics.OpenGL;

namespace OxygenEngineCore.Primitive;

public class MeshRenderer : Renderer , IDisposable {
    internal Mesh mesh;


    public override void Render(Shader shader) {
        
        Vao = new VertexArrayObject();
        Vao.Bind();

        Vertex_VBO = new VertexBufferObject(mesh.Vertices);
        Vertex_VBO.BindBuffer();
        Vao.BindVertexArray(0, 3, Vertex_VBO);

        UV_VBO = new VertexBufferObject(mesh.UVs);
        UV_VBO.BindBuffer();
        Vao.BindVertexArray(1, 2, UV_VBO);

        Index_IBO = new IndexBufferObject(mesh.Indices);


        texture = new Texture("texturePath");
        
        
        shader.Bind();
        var ScaledTransform = TransformMatrix * ScaleMatrix;
        var offset = GL.GetUniformLocation(shader.ID, "transform");
        GL.UniformMatrix4(offset, true, ref ScaledTransform);

        Vao.Bind();
        Index_IBO.BindBuffer();
        texture.Bind();

        GL.DrawElements(BeginMode.Triangles, mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }

    public void Dispose() {
        Vao.Dispose();
        Vertex_VBO.Dispose();
        Index_IBO.Dispose();
        UV_VBO.Dispose();
        texture.Dispose();
    }
}