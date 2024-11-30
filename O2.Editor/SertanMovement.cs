using OxygenEngine.Scripting;
using OxygenEngineCore.InputSystem;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Primitive.Lib;

namespace Runtime;

public class SertanMovement : CoreBehaviour {
    MeshRenderer renderer;
    internal override void OnBegin() {
        renderer = GetComponent<MeshRenderer>();
    }

    internal override void OnTick(float deltaTime) {
        if (Input.IsKeyPressed(Key.K))
        {
            renderer.texture.textureMetaGuid = "261fb487-1c2b-47ab-8b5b-f86d3710a7c2";
            renderer.PrepareToRender();
        }
    }
}