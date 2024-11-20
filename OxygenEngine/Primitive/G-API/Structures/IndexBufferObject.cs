using OpenTK.Graphics.OpenGL;
namespace OxygenEngineCore.Primitive;

public class IndexBufferObject {
    internal int ID { get; set; }
    public BufferUsageHint UsageHint { get; set; } = BufferUsageHint.StaticDraw;
    
    public IndexBufferObject(uint[]? Data) {
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
        GL.BufferData(BufferTarget.ElementArrayBuffer, Data.Length * sizeof(uint), Data, UsageHint);
    }
    
    public void BindBuffer() {
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
    }
    public void UnbindBuffer() {
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    }
    public void Dispose() {
        GL.DeleteBuffer(ID);
    }
    
}