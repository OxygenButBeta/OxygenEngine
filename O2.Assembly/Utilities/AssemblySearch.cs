using System.Reflection;

namespace OxygenEngine.AssemblyCompiler.Utilities;
//TODO: Implement a proper assembly search utility 
public static class AssemblySearch {
    public static IEnumerable<Type> FindAllDerivedTypesInAssembly<T>(Assembly assembly) {
        var baseTarget = typeof(T);

        return assembly.GetTypes()
            .Where(t => t.IsSubclassOf(baseTarget))
            .ToList();
    }
}