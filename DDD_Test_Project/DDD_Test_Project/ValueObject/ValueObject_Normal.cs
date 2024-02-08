namespace DDD_Test_Project.ValueObject;

public class ValueObject_Normal_readonly
{
    public readonly string name;
    public readonly string value;

    public ValueObject_Normal_readonly(string name, string value)
    {
        this.name = name;
        this.value = value;
    }
}

public class ValueObject_Normal_property
{
    public string Name { get; private set; }
    public string Value { get; private set; }

    public ValueObject_Normal_property(string name, string value)
    {
        Name = name;
        Value = value;
    }
}


public class FullName
{
    public string FirstName { get; }
    public string LastName { get; }

    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public class FullName_IEquatable : IEquatable<FullName_IEquatable>
{
    public FullName_IEquatable(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public bool Equals(FullName_IEquatable other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FullName_IEquatable)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
        }
    }
}