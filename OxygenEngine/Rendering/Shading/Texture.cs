using OpenTK.Graphics.OpenGL;
using OxygenEngine.AssetDatabase;
using OxygenEngine.Database.Meta;
using OxygenEngine.Serialization;
using OxygenEngineCore.Primitive.Lib;
using StbImageSharp;
using static OxygenEngine.AssetDatabase.AssetDatabase;

namespace OxygenEngineCore.Rendering;

public sealed class Texture : ISerializableEntity, IAssetImporter<Texture> {
    public int ID { get; set; }
    public   string textureMetaGuid = "46fec3cf-2021-42de-a8bb-34d0755c8653"; // Default texture
    ImageResult texture;

    void gpuTexture() {

        ID = GL.GenTexture();
         texture = ImageResult.FromStream(
            File.OpenRead((GuidToMetaData(textureMetaGuid).GetExactPathFromMeta())),
            ColorComponents.RedGreenBlueAlpha);
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, ID);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
            (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
            (int)TextureMagFilter.Nearest);

        StbImage.stbi_set_flip_vertically_on_load(1);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height,
            0, PixelFormat.Rgba, PixelType.UnsignedByte, texture.Data);
        UnBind();
    }

    public void Bind() {
        gpuTexture();

        GL.BindTexture(TextureTarget.Texture2D, ID);
    }

    public void UnBind() {
        GL.BindTexture(TextureTarget.Texture2D, 0);
    }

    public void Dispose() {
        GL.DeleteTexture(ID);
    }

    public Dictionary<string, string> Serialize() {
        var dict = new Dictionary<string, string>();
        dict.Add("TextureMetaGuid", textureMetaGuid);

        return dict;
    }

    public void Deserialize(Dictionary<string, string> data) {
        textureMetaGuid = data["TextureMetaGuid"];
        ImportAsset();
        gpuTexture();
    }

    public Texture ImportAsset() {
        texture = ImageResult.FromStream(
            File.OpenRead((GuidToMetaData(textureMetaGuid).GetExactPathFromMeta())),
            ColorComponents.RedGreenBlueAlpha);
        return this;
    }
}