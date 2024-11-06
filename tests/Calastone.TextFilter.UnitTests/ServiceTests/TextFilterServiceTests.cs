using Calastone.TextFilter.Services;
using FluentAssertions;
using Moq;

namespace Calastone.TextFilter.UnitTests.ServiceTests;

public class TextFilterServiceTests
{
    private readonly ITextFilterService _sut;
    private readonly Mock<IFileReaderService> _fileReaderService;

    public TextFilterServiceTests()
    {
        _fileReaderService = new Mock<IFileReaderService>();
        _sut = new TextFilterService(_fileReaderService.Object);
    }

    [Fact]
    public async Task GivenTextFiltersService_WhenProcessingText_ItAppliesFiltersToTheReadText()
    {
        //Arrange
        var data = new List<string> { "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice" };
        _fileReaderService.Setup(x => x.ReadFileAsync()).Returns(data.ToAsyncEnumerable());

        //Act
        var result = await _sut.Process().ToListAsync();

        //Assert
        result.Should().BeEquivalentTo(new string[] {"", "", "beginning", "", "", "", "", "", "", "", "", "", "", "", "", "and", "", "", "", "", "", "once", "", "", ""});
    }
}