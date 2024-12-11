namespace OxygenEngineCore;

public partial class WorldObject : IEquatable<WorldObject> {
    public bool Equals(WorldObject other) {
        return this.InstanceID == other.InstanceID;
    }

    public override bool Equals(object obj) {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((WorldObject)obj);
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }
}