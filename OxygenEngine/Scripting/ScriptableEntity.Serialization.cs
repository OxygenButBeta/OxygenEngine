using Newtonsoft.Json;
using OxygenEngine.Serialization;

namespace OxygenEngine.Scripting;

public abstract partial class CoreBehaviour {
    [Serializable]
    class KeyPair {
        public string name;
        public string value;

        internal KeyPair(string name, string value) {
            this.name = name;
            this.value = value;
        }
    }

    public override Dictionary<string, string> Serialize() {
        var SerializedFields = SerializedFieldAttribute.GetAllSerializedVariables(this);
        var result = new Dictionary<string, string>();
        foreach (var fieldInfo in SerializedFields)
        {
            result.Add(fieldInfo.Name,
                JsonConvert.SerializeObject(new KeyPair(fieldInfo.Name, fieldInfo.GetValue(this).ToString())));
        }

        return result;
    }

    public override void Deserialize(Dictionary<string, string> data) {
        var SerializedFields = SerializedFieldAttribute.GetAllSerializedVariables(this);
        (string name, string value) pair;
        foreach (var fieldInfo in SerializedFields)
        {
            if (!data.TryGetValue(fieldInfo.Name, out var value1))
                continue;

            var deserializedValue = JsonConvert.DeserializeObject<KeyPair>(value1);
            fieldInfo.SetValue(Convert.ChangeType(deserializedValue.value, fieldInfo.FieldType), this);
        }
    }
}