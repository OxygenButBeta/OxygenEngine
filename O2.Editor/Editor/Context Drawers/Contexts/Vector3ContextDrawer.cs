using ImGuiNET;
using OpenTK.Mathematics;

namespace OxygenEngineRuntime.Editor.ContextDrawers.Contexts;

public static class Vector3ContextDrawer {
    private static readonly Dictionary<int, System.Numerics.Vector3> stateCache = new();

    public static Vector3 Draw(Vector3 vec3, string label, int uniqueKey = 0) {
        if (!stateCache.ContainsKey(uniqueKey))
            stateCache[uniqueKey] = new System.Numerics.Vector3(vec3.X, vec3.Y, vec3.Z);


        var cachedVector = stateCache[uniqueKey];

        ImGui.Text(label);
        if (!ImGui.InputFloat3(uniqueKey.ToString(), ref cachedVector))
            return vec3;
        stateCache[uniqueKey] = cachedVector;
        vec3 = new Vector3(cachedVector.X, cachedVector.Y, cachedVector.Z);

        return vec3;
    }
}