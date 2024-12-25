using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OxygenEngineCore.InputSystem;


/// <summary>
/// Simple Binding for OpenTK KeyboardState
/// </summary>
public static  class Input  {
    static KeyboardState keyboardState;
    public static MouseState mouseState;

    /// <summary>
    /// Returns true if the key is currently pressed
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool IsKeyDown(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyDown((Keys)keyVal);
    }
    
    /// <summary>
    /// returns true if the key is currently released
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool IsKeyReleased(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyReleased((Keys)keyVal);
    }

    /// <summary>
    /// Returns true if the key was pressed this frame
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool IsKeyPressed(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyPressed((Keys)keyVal);
    }

    public static void Update(IGL gl) {
        keyboardState = gl.KeyboardState;
    }
}