using Newtonsoft.Json;
using OxygenEngine.Serialization;

namespace OxygenEngine.Scripting {
    public abstract partial class CoreBehaviour {
        public override Dictionary<string, string> Serialize() {
            var SerializedFields = SerializedFieldAttribute.GetAllSerializedVariables(this);
            return SerializedFields.ToDictionary(fieldInfo => fieldInfo.Name, fieldInfo => JsonConvert.SerializeObject(new KeyPair(fieldInfo.Name, fieldInfo.GetValue(this).ToString())));
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
}