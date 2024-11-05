using Calastone.TextFilter.Services;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.ServiceTests;

public class TextFilterServiceTests
{
    private readonly ITextFilterService _sut;

    public TextFilterServiceTests()
    {
        _sut = new TextFilterService();
    }
    
    [Fact]
    public void GivenTextFiltersAdded_WhenProcessingText_ThenReturnsTrue()
    {
        //Arrange
        var sampleText = "sample text";
        //Act
        var result = _sut.Process(sampleText);
        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenTextFiltersService_WhenProcessingText_ItReadsTextFromFile()
    {
        var sampleText = "sample text";
    }
}