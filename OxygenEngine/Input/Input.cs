﻿using O2Common.EnginePlugins;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OxygenEngineCore.InputSystem;

public class Input : IEngineService {
    static KeyboardState keyboardState;
    public static MouseState mouseState;

    public static bool IsKeyDown(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyDown((Keys)keyVal);
    }
    public static bool IsKeyReleased(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyReleased((Keys)keyVal);
    }

    public static bool IsKeyPressed(Key key) {
        var keyVal = (int)key;
        return keyboardState.IsKeyPressed((Keys)keyVal);
    }

    public static void Update(GLRenderWindow gl) {
        keyboardState = gl.KeyboardState;
    }
}