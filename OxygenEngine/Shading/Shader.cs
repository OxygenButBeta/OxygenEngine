using OpenTK.Graphics.OpenGL;
namespace OxygenEngineCore.Rendering;

public class Shader {
    public int ID { get; set; }
    public Shader(string vertexPath, string fragmentPath) {
        ID = GL.CreateProgram();

        var vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexPath);
        GL.CompileShader(vertexShader);

        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentPath);
        GL.CompileShader(fragmentShader);
        GL.AttachShader(ID, vertexShader);
        GL.AttachShader(ID, fragmentShader);
        GL.LinkProgram(ID);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);

    }

    public void Bind() {
        GL.UseProgram(ID);
    }
    public void UnBind() {
        GL.UseProgram(0);
    }
    public void Dispose() {
        GL.DeleteProgram(ID);
    }
}