using DDD_Test_Project.ValueObject_ValueObject;

namespace DDD_Test_Project.Test.ValueObject;

public class ValueObject_ValueObject
{
    [Theory(DisplayName = "FullName Equality Tests")]
    [InlineData("John", "Doe", "John", "Doe", true)]
    [InlineData("John", "Doe", "Jane", "Doe", false)]
    public void FullNameEqualityTests(string firstName1, string lastName1, string firstName2, string lastName2, bool expected)
    {
        // Arrange
        var fullName1 = new FullName(firstName1, lastName1);
        var fullName2 = new FullName(firstName2, lastName2);

        // Act
        bool result = fullName1.Equals(fullName2);
        bool resultEqual = fullName1 == fullName2;

        // Assert
        result.Should().Be(expected);
        resultEqual.Should().Be(expected);
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

    [Theory(DisplayName = "FullName Equality Tests 2")]
    [InlineData("John", "Doe", "John", "Doe", true)]
    [InlineData("John", "Doe", "Jane", "Doe", false)]
    public void FullNameEqualityTests_2(string firstName1, string lastName1, string firstName2, string lastName2, bool expected)
    {
        // Arrange
        var fullName1 = new FullName_2(firstName1, lastName1);
        var fullName2 = new FullName_2(firstName2, lastName2);

        // Act
        bool result = fullName1.Equals(fullName2);
        bool resultEqual = fullName1 == fullName2;

        // Assert
        result.Should().Be(expected);
        resultEqual.Should().Be(expected);
    }

    [Theory(DisplayName = "Name Equality Tests 2")]
    [InlineData("John", "John", true)]
    [InlineData("John", "Jane", false)]
    public void NameEqualityTests_2(string value1, string value2, bool expected)
    {
        // Arrange
        var name1 = new Name_2(value1);
        var name2 = new Name_2(value2);

        // Act
        bool result = name1.Equals(name2);
        bool resultEqual = name1 == name2;

        // Assert
        result.Should().Be(expected);
        resultEqual.Should().Be(expected);
    }

    [Fact(DisplayName = "Name Exception Test")]
    public void NameExceptionTest()
    {
        // Arrange
        string value = "NameLongerThan10Characters";

        // Act
        Action createName = () => new Name(value);

        // Assert
        createName.Should().Throw<ArgumentException>();
    }
}
