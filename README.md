![{D031B2DB-BDC3-4412-B985-A1B02281B20C}](https://github.com/user-attachments/assets/2368927e-3931-4b76-b787-434c99bad1ae)

# Oxygen Game Engine (C# & OpenTK)

This is an OpenGL-based game engine that I’ve been developing in my free time using C# and OpenTK. The engine is inspired by Unity and is still in the early stages of development. Currently, one of the main challenges is the lack of shading, but I plan to address this soon. In the video linked below.

## Current Features

### 1. Component System
The engine includes a `CoreBehaviour` base class, inspired by Unity’s component system. It supports callbacks like `Start`, `Update`, and `OnDisable`. Components derived from this base class can be active at runtime and attached to objects in the editor.

### 2. Asset Database
Similar to Unity, the engine creates `.meta` files for assets. GUID-based operations allow for safe object reference management, including serialization, file saving, and loading.

### 3. Input System
The engine features a classic input system, similar to Unity’s, with functions like `GetKey`, `KeyDown`, etc., to handle user input.

### 4. Batching and Rendering
Meshes that need to be rendered are queued in the render pipeline. When the main object (similar to Unity's `GameObject`, here called `WorldObject`) is disabled, its mesh is automatically removed from the render queue. Static objects are only recalculated once, as their positions do not change. Planned features include occlusion culling, GPU instancing, and material optimizations.

### 5. Editor
The engine uses an ImGui-based UI system for its editor. Each editor tool, derived from the `EditorWindow` base class, is called every frame, with the `Draw` method used to build the UI. Similar to Unity’s Property Drawer system, custom drawers for types such as boolean, string, `Vector3`, and `Quaternion` can be written and edited through the UI.

### 6. Serialization
With the `[SerializeField]` attribute, fields can be made editable in the editor. Scene and object parameters are serialized to files, allowing for saving and loading of game data.

