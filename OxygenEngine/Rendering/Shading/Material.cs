namespace OxygenEngineCore.Rendering.Shading;

public class Material {
    public Material(Texture texture, Shader shader) {
        Texture = texture;
        Shader = shader;
    }

    public Texture Texture { get; set; }
    public Shader Shader { get; set; }

    public void Bind() {
        Texture.Bind();
        Shader.Bind();
    }
    public void Unbind() {
        Texture.UnBind();
        Shader.UnBind();
    }
}