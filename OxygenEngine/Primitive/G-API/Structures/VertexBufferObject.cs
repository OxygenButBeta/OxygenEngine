using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace OxygenEngineCore.Primitive;

public class VertexBufferObject {
    public int ID { get; }

    public BufferUsageHint UsageHint { get; set; } = BufferUsageHint.StaticDraw;
    public VertexBufferObject(Vector3[]? Data) {
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, Data.Length * Vector3.SizeInBytes, Data, UsageHint);
    }

    public VertexBufferObject(Vector2[]?  Data) {
        ID = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        GL.BufferData(BufferTarget.ArrayBuffer, Data.Length * Vector2.SizeInBytes, Data, UsageHint);
    }

    public void BindBuffer() {
        GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
    }
    public void UnbindBuffer() {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }
    public void Dispose() {
        GL.DeleteBuffer(ID);
    }
}