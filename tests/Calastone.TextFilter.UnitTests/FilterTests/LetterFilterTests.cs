using Calastone.TextFilter.Filters;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.FilterTests;

public class LetterFilterTests
{
    private LetterFilter _sut;

    public LetterFilterTests()
    {
        _sut = new LetterFilter();
    }

    [Fact]
    public void LetterFilter_ImplementsAbstractClass()
    {
        var isSubclassOf = _sut.GetType().IsSubclassOf(typeof(WordFilter));
        isSubclassOf.Should().BeTrue();
    }

    [Fact]
    public void LetterFilterIsAssignable_ToITextFilter()
    {
        var result = typeof(IWordFilter).IsAssignableFrom(_sut.GetType());
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenLetterFilterIsInstantiated_WhenIsEnabledIsCalled_ThenReturnsTrue()
    {
        var isEnabled = _sut.IsEnabled();
        isEnabled.Should().BeTrue();
    }

    [Theory]
    [InlineData("that")]
    [InlineData("then")]
    [InlineData("the")]
    [InlineData("ofTen")]
    [InlineData("often")]
    [InlineData("to")]
    public void GivenLetterFilterIsApplied_WhenTheWordContainsLetterT_ThenReturnsEmptyString(string word)
    {
        var result = _sut.Apply(word);
        result.Should().BeEmpty();
    }

    [Theory]
    [InlineData("now")]
    [InlineData("hours")]
    [InlineData("words")]
    public void GivenLetterFilterIsApplied_WhenTheWordDoesNotContainsLetterT_ThenReturnsTheWord(string word)
    {
        var result = _sut.Apply(word);
        result.Should().Be(word);
    }

    [Theory]
    [InlineData("ofTen")]
    [InlineData("often")]
    [InlineData("To")]
    [InlineData("to")]
    public void GivenLetterFilterIsApplied_WhenTheWordContainsLetterT_ThenReturnsEmptyStringRegardlessOfTheCasing(
        string word)
    {
        var result = _sut.Apply(word);
        result.Should().BeEmpty();
    }
}