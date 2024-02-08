using DDD_Test_Project.Common;

namespace DDD_Test_Project.ValueObject_ValueObject;

public class FullName : Common.ValueObject_Normal
{
    public string FirstName { get; }
    public string LastName { get; }

    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}

public class Name : Common.ValueObject_Normal
{
    public Name(string value)
    {
        if (value.Length > 10)
            throw new ArgumentException("Name length must be 10 characters or less.");

        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

public sealed class FullName_2 : ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }

    public FullName_2(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FirstName;
        yield return LastName;
    }
}

public sealed class Name_2 : ValueObject
{
    public Name_2(string value)
    {
        if (value.Length > 10)
            throw new ArgumentException("Name length must be 10 characters or less.");

        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

