using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive.Lib;

public interface IDrawCallElement  : IDisposable{
    public void PrepareToRender();
    public void DrawCall(Shader shader);
}