using OpenTK.Mathematics;

namespace OxygenEngineCore.Primitive;

public partial class MeshRenderer {
    internal override void OnBegin() {
        mesh = new Mesh();
        mesh.renderer = this;
        mesh.ModelMetaGuid = "b46e55cd-bd7c-46d8-b494-564358dd85f4";
        PrepareToRender();
        
    }

    void LinkShaderUniforms() {
        if (worldObject.IsStatic)
            return; // Static objects don't need to update their uniforms every frame

        ScaleMatrix = Matrix4.CreateScale(worldObject.Transform.Scale);
        TransformMatrix = Matrix4.CreateTranslation(worldObject.Transform.Position);
        RotationMatrix = Matrix4.CreateFromQuaternion(worldObject.Transform.Rotation);
    }

    internal override void OnTick(float deltaTime) {
        LinkShaderUniforms();
    }
}