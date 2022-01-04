namespace Models.Enums;

public abstract class Enumeration : IComparable
{
    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public int Id { get; private set; }
    public string Name { get; private set; }

    public override string ToString() => Name;

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue) return false;

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? other) => Id.CompareTo((other as Enumeration)?.Id);

    public override int GetHashCode() => Id.GetHashCode();
}
