namespace DDD_Test_Project.ValueObject_Record;

public record FullName(string FirstName, string LastName);

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (value.Length > 10)
            throw new ArgumentException("Name cannot be longer than 10 characters.");
        Value = value;
    }
}