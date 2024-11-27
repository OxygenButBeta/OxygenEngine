using OpenTK.Graphics.OpenGL;
namespace OxygenEngineCore.Primitive;

public class VertexArrayObject : IDisposable {
    internal int ID { get; set; }
    public VertexArrayObject() {
        ID = GL.GenVertexArray();
        GL.BindVertexArray(ID);
    }
    public void BindVertexArray(int location,int size) {
        Bind();
        GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(location);
    }
    public void Bind() {
        GL.BindVertexArray(ID);
    }
    public void Dispose() {
        
        GL.BindVertexArray(0);
        GL.DeleteVertexArray(ID);
    }
    
}