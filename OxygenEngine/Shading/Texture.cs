using OpenTK.Graphics.OpenGL;
using StbImageSharp;
namespace OxygenEngineCore.Rendering;

public class Texture {
    public int ID { get; set; }

    public Texture(string path) {
        ID = GL.GenTexture();
        
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, ID);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
            (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
            (int)TextureMagFilter.Nearest);
        
        StbImage.stbi_set_flip_vertically_on_load(1);
        var texture = ImageResult.FromStream(File.OpenRead("../../../Textures/"+path),
            ColorComponents.RedGreenBlueAlpha);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height,
            0, PixelFormat.Rgba, PixelType.UnsignedByte, texture.Data);
        UnBind();

    }
    public void Bind() {
        GL.BindTexture(TextureTarget.Texture2D, ID);
    }
    public void UnBind() {
        GL.BindTexture(TextureTarget.Texture2D, 0);
    }
    public void Dispose() {
        GL.DeleteTexture(ID);
    }
    
}