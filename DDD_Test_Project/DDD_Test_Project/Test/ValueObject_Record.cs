using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_Test_Project.ValueObject_Record;


namespace DDD_Test_Project.Test;

public class ValueObject_Record
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

    [Theory(DisplayName = "Name Equality Tests 2")]
    [InlineData("John", "John", true)]
    [InlineData("John", "Jane", false)]
    public void NameEqualityTests_2(string value1, string value2, bool expected)
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
