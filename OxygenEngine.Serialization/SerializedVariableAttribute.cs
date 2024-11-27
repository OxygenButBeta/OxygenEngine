using System.Reflection;

namespace OxygenEngine.Serialization;

[AttributeUsage(AttributeTargets.Field)]
public class SerializedVariableAttribute : Attribute {
    public static List<FieldInfo> GetAllSerializedVariables(object instance) {
        var fields = instance.GetType().GetFields();
        var result = new List<FieldInfo>();
        foreach (var field in fields)
        {
            var attribute = field.GetCustomAttribute<SerializedVariableAttribute>();
            if (attribute != null)
            {
                result.Add(field);
            }
        }
        return result;
    }
}