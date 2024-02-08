using DDD_Test_Project.Common;

namespace DDD_Test_Project.ValueObject_ValueObject;

public class FullName : ValueObject
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

public class Name : ValueObject
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