using System.Reflection;

namespace OxygenEngine.AssemblyCompiler.Utilities;

public class AssemblySearch {
    public static IEnumerable<Type> FindAllDerivedTypesInAssembly<T>(Assembly assembly) {
        var baseTarget = typeof(T);

        return assembly.GetTypes()
            .Where(t => t.IsSubclassOf(baseTarget))
            .ToList();
    }
}