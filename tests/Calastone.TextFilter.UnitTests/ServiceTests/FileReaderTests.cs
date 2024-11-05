using Calastone.TextFilter.Services;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.ServiceTests;

public class FileReaderServiceTests
{
    private readonly FileReaderService _sut;

    public FileReaderServiceTests()
    {
        _sut = new FileReaderService();
    }

    [Fact]
    public async Task GivenATextFile_WhenFileReaderServiceIsCalled_ThenTheReturnedLinesShouldNotBeEmpty()
    {
        //Act
        //Assert
        await foreach (var line in _sut.ReadFileAsync())
        {
            line.Should().NotBeEmpty();
        }
    }

    [Fact]
    public async Task GivenATextFile_WhenFileReaderServiceIsCalled_ThenTheFirstLineShouldBeCorrectlyReturned()
    {
        //Act
        //Assert
        var lines = await _sut.ReadFileAsync().ToListAsync();
        lines.ElementAt(0).Should()
            .Be(
                "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice");
    }

    [Fact]
    public async Task GivenATextFile_WhenFileReaderServiceIsCalled_ThenTheLineNumbersCountShouldBeCorrect()
    {
        //Act
        //Assert
        var lines = await _sut.ReadFileAsync().ToListAsync();
        lines.Count().Should().Be(21);
    }
}