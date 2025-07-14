# 🚀 Oxygen Engine (C# & OpenTK)

**Oxygen Engine** is an OpenGL-based game engine developed using **C#** and **OpenTK**. Inspired by **Unity**, it’s currently in early development stages.  
⚠️ One current challenge: **No shading support yet** — but it’s coming soon!

---

### ⚙️ Core Features

🧩 **Component System**  
- Inspired by Unity’s component architecture with a `CoreBehaviour` base class.  
- Supports lifecycle callbacks like `Start`, `Update`, and `OnDisable`.  
- Components derived from `CoreBehaviour` can be attached to objects in-editor and activated at runtime.  
- Automatic runtime detection of all `CoreBehaviour`-derived types — no manual registration needed!  

```csharp
public class CharacterController : CoreBehaviour {
    [SerializedField] 
    float speed = 1.0f;

    internal override void OnTick(float deltaTime) {
        var nextPos = transform.Position;
        if (Input.IsKeyDown(Key.Up))
            nextPos.Z -= speed * deltaTime;
         // Handle Other Directions.
        transform.Position = nextPos;
    }

    internal override void OnActiveStateChange(bool active) {
        // Called when the component is enabled or disabled
    }
}

## 📁 Asset Database

- Generates `.meta` files like Unity.  
- Uses GUIDs to safely serialize, save, and load assets.

---

## 🎮 Input System

- Classic input API similar to Unity (`GetKey`, `KeyDown`, etc.) for handling user input.

---

## 🎨 Batching & Rendering

- Meshes queued for rendering in the pipeline.  
- Disabling `WorldObject` removes its mesh automatically.  
- Static objects recalculated once only.  

### Planned Features:  
- 🔲 Occlusion Culling  
- 🖥️ GPU Instancing  
- 🎨 Material Optimizations  

---

## 🛠️ Editor

- Built with ImGui UI system.  
- Editor tools derive from `EditorWindow` and use the `Draw` method to build UI every frame.  
- Supports custom property drawers (`bool`, `string`, `Vector3`, `Quaternion`, etc.) similar to Unity.

---

## 💾 Serialization

- `[SerializeField]` attributes make fields editable in the editor.  
- Scene and object parameters serialize to files for save/load functionality.

---

## 🛣️ Roadmap

- ✨ Add shading support  
- 🚧 Implement occlusion culling & GPU instancing  
- 🎨 Enhance material and asset optimization  
- 🛠️ Expand editor features and tooling
