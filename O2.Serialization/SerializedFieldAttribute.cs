using System.Reflection;

namespace OxygenEngine.Serialization;

[AttributeUsage(AttributeTargets.Field)]
public class SerializedFieldAttribute : Attribute {
    public static List<FieldInfo> GetAllSerializedVariables(object instance) {
        var fields = instance.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var result = new List<FieldInfo>();
        foreach (var field in fields)
        {
            var attribute = field.GetCustomAttribute<SerializedFieldAttribute>();
            if (attribute != null)
            {
                result.Add(field);
            }
        }
        return result;
    }
}