namespace DDD_Test_Project.ValueObject_Normal;

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
public class Name : IEquatable<Name>
{
    public Name(string value)
    {
        if (value.Length > 10)
        {
            throw new ArgumentException("Name length must be 10 characters or less.");
        }

        Value = value;
    }

    public string Value { get; }

    public bool Equals(Name other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Name)obj);
    }

    public override int GetHashCode()
    {
        return (Value != null ? Value.GetHashCode() : 0);
    }

    public static bool operator ==(Name name1, Name name2)
    {
        if (ReferenceEquals(name1, name2))
        {
            return true;
        }

        if (ReferenceEquals(null, name1) || ReferenceEquals(null, name2))
        {
            return false;
        }

        return name1.Equals(name2);
    }

    public static bool operator !=(Name name1, Name name2)
    {
        return !(name1 == name2);
    }
}