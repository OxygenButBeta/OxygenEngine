namespace OxygenEngine.Serialization;

public interface ISerializableEntity {
    Dictionary<string, string> Serialize();
    void Deserialize(Dictionary<string, string> data);
}