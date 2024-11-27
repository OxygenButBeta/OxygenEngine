using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive.Lib;

public interface IDrawCallElement  : IDisposable{
    public void DrawCall(Shader shader);
    public VertexArrayObject Vao { get; }
}