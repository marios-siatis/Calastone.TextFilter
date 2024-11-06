using Calastone.TextFilter.Extensions;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void GiveAStringWithNonAlphaNumeric_ShouldReturnOnlyLetters()
    {
        // Arrange
        var input = "Hello,World!123";

        // Act
        var result = input.RemoveNonAlphabetic();

        // Assert
        result.Should().Be("HelloWorld");
    }
    
    [Fact]
    public void GiveInputHasOnlyLetters_ShouldReturnOriginal()
    {
        // Arrange
        var input = "HelloWorld";

        // Act
        var result = input.RemoveNonAlphabetic();

        // Assert
        result.Should().Be(input);
    }
    
    [Fact]
    public void GivenEmptyInput_ShouldReturnEmpty()
    {
        // Arrange
        var input = "";

        // Act
        var result = input.RemoveNonAlphabetic();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GivenNullInput_ShouldReturnEmpty()
    {
        // Arrange
        string input = null;

        // Act
        var result = input.RemoveNonAlphabetic();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void RemoveNonAlphabetic_ShouldHandleUnicodeLetters()
    {
        // Arrange
        string input = "Héllo,Wørld!";

        // Act
        string result = input.RemoveNonAlphabetic();

        // Assert
        result.Should().Be("HélloWørld");
    }

  
}