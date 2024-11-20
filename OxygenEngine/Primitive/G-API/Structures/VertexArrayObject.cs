using OpenTK.Graphics.OpenGL;
namespace OxygenEngineCore.Primitive;

public class VertexArrayObject {
    internal int ID { get; set; }
    public VertexArrayObject() {
        ID = GL.GenVertexArray();
        GL.BindVertexArray(ID);
    }
    public void BindVertexArray(int location,int size,VertexBufferObject? vbo) {
        Bind();
        vbo.BindBuffer();
        GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(location);
        UnbindVertexArray();
    }
    public void Bind() {
        GL.BindVertexArray(ID);
    }
    public void UnbindVertexArray() {
        GL.BindVertexArray(0);
    }
    public void Dispose() {
        GL.DeleteVertexArray(ID);
    }
    
}