using Calastone.TextFilter.Filters;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.FilterTests;

public class VowelFilterTests
{
    private readonly VowelFilter _sut;

    public VowelFilterTests()
    {
        _sut = new VowelFilter();
    }

    [Fact]
    public void VowelFilter_ImplementsAbstractClass()
    {
        var isSubclassOf = _sut.GetType().IsSubclassOf(typeof(WordFilter));
        isSubclassOf.Should().BeTrue();
    }

    [Fact]
    public void VowelFilterIsAssignable_ToITextFilter()
    {
        var result = typeof(IWordFilter).IsAssignableFrom(_sut.GetType());
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenVowelFilterIsInstantiated_WhenIsEnabledIsCalled_ThenReturnsTrue()
    {
        var isEnabled = _sut.IsEnabled();
        isEnabled.Should().BeTrue();
    }

    [Theory]
    [InlineData("the", "the")]
    [InlineData("rather", "rather")]
    public void GivenAWordWithNoVowelsInTheMiddle_WhenApplyIsCalled_ThenIsShouldReturnTheWord(string word, string expected)
    {
        var result = _sut.Apply(word);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("the!", "the!")]
    [InlineData("the,", "the,")]
    public void GivenAWordWithNoVowelsInTheMiddleAndPunctuation_WhenApplyIsCalled_ThenIsShouldReturnTheWord(string word, string expected)
    {
        var result = _sut.Apply(word);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("clean", "")]
    [InlineData("what", "")]
    [InlineData("currently", "")]
    public void GivenAWordWithVowelsInTheMiddle_WhenApplyIsCalled_ThenIsShouldReturnEmptyString(string word, string expected)
    {
        var result = _sut.Apply(word);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("clean!", "")]
    [InlineData("what.", "")]
    [InlineData("currently,", "")]
    public void GivenAWordWithVowelsInTheMiddleAndPunctuation_WhenApplyIsCalled_ThenIsShouldReturnEmptyString(string word, string expected)
    {
        var result = _sut.Apply(word);
        result.Should().Be(expected);
    }
}