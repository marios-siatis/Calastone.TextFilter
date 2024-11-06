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
        var data = new List<string> { "the quick brown fox jumps over the lazy dog" };
        _fileReaderService.Setup(x => x.ReadFileAsync()).Returns(data.ToAsyncEnumerable());

        //Act
        var result = await _sut.Process().ToListAsync();

        //Assert
        result.Should().BeEquivalentTo(new string[] {"", "", "", "", "jumps", "", "", "", "", ""});
    }
}