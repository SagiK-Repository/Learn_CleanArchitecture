using DDD_Test_Project.ValueObject_Normal;

namespace DDD_Test_Project.Test;

public class ValueObject_Normal
{
    [Theory(DisplayName = "ValueObject_Normal_readonly Tests")]
    [InlineData("name1", "value1")]
    [InlineData("name2", "value2")]
    public void ValueObjectNormalReadonlyTests(string name, string value)
    {
        // Arrange

        // Act
        var valueObject = new ValueObject_Normal_readonly(name, value);

        // Assert
        valueObject.name.Should().Be(name);
        valueObject.value.Should().Be(value);
    }

    [Theory(DisplayName = "ValueObject_Normal_property Tests")]
    [InlineData("name1", "value1")]
    [InlineData("name2", "value2")]
    public void ValueObjectNormalPropertyTests(string name, string value)
    {
        // Arrange

        // Act
        var valueObject = new ValueObject_Normal_property(name, value);

        // Assert
        valueObject.Name.Should().Be(name);
        valueObject.Value.Should().Be(value);
    }

    [Theory(DisplayName = "FullName Property Tests")]
    [InlineData("John", "Doe")]
    [InlineData("Jane", "Smith")]
    public void FullNamePropertyTests(string firstName, string lastName)
    {
        // Arrange & Act
        var fullName = new FullName(firstName, lastName);

        // Assert
        fullName.FirstName.Should().Be(firstName);
        fullName.LastName.Should().Be(lastName);
    }

    [Theory(DisplayName = "FullName Equality Tests")]
    [InlineData("John", "Doe", "John", "Doe", true)]
    [InlineData("John", "Doe", "Jane", "Doe", false)]
    [InlineData("John", "Doe", "John", "Smith", false)]
    [InlineData("John", "Doe", "Jane", "Smith", false)]
    public void FullNameEqualityTests(string firstName1, string lastName1, string firstName2, string lastName2, bool expected)
    {
        // Arrange
        var fullName1 = new FullName_IEquatable(firstName1, lastName1);
        var fullName2 = new FullName_IEquatable(firstName2, lastName2);

        // Act
        bool result = fullName1.Equals(fullName2);
        bool resultEqual = fullName1 == fullName2;

        // Assert
        result.Should().Be(expected);
        resultEqual.Should().BeFalse();
    }

    [Theory(DisplayName = "Name Equality Tests")]
    [InlineData("John", "John", true)]
    [InlineData("John", "Jane", false)]
    public void NameEqualityTests(string value1, string value2, bool expected)
    {
        // Arrange
        var name1 = new Name(value1);
        var name2 = new Name(value2);

        // Act
        bool result = name1.Equals(name2);
        bool resultEqual = name1 == name2;

        // Assert
        result.Should().Be(expected);
        resultEqual.Should().Be(expected);
    }
}