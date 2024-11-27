using System.Reflection;
using OxygenEngine.AssemblyCompiler.Utilities;
using OxygenEngine.Scripting;
using OxygenEngineCore.Primitive;

namespace OxygenEngineCore;

public static class ComponentUtility {
    static readonly List<Type> components = new();
    static bool Initialized;

    public static IEnumerable<Type> ComponentTypesInAssembly(Assembly assembly) {
        if (Initialized)
            return components;

        components.AddRange(AssemblySearch.FindAllDerivedTypesInAssembly<CoreBehaviour>(assembly));
        components.Add(typeof(MeshRenderer));

        Initialized = true;
        return components;
    }
}