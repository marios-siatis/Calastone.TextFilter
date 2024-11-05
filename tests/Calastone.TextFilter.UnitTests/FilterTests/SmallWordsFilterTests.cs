using System.Runtime.InteropServices;
using Calastone.TextFilter.Filters;
using FluentAssertions;

namespace Calastone.TextFilter.UnitTests.FilterTests;

public class SmallWordsFilterTests
{
   private SmallWordsFilter _sut;

   public SmallWordsFilterTests()
   {
      _sut = new SmallWordsFilter();
   }

   [Fact]
   public void SmallWordsFilter_ImplementsAbstractClass()
   {
      var isSubclassOf = _sut.GetType().IsSubclassOf(typeof(WordFilter));
      isSubclassOf.Should().BeTrue();
   }

   [Fact]
   public void SmallWordsFilterIsAssignable_ToITextFilter()
   {
      var result = typeof(IWordFilter).IsAssignableFrom(_sut.GetType());
      result.Should().BeTrue();
   }

   [Fact]
   public void GivenSmallWordsFilterIsInstantiated_WhenIsEnabledIsCalled_ThenReturnsTrue()
   {
      var isEnabled = _sut.IsEnabled();
      isEnabled.Should().BeTrue();
   }
   
   [Theory]
   [InlineData("to")]
   [InlineData("a")]
   public void GivenSmallWordsFilterIsApplied_WhenSmallWordIsPassed_ThenReturnsEmptyString(string word)
   {
      var isEnabled = _sut.Apply(word);
      isEnabled.Should().Be(string.Empty);
   }
   
   [Theory]
   [InlineData("the")]
   [InlineData("that")]
   [InlineData("fly")]
   public void GivenSmallWordsFilterIsApplied_WhenLargeWordIsPassed_ThenReturnsEmptyString(string word)
   {
      var isEnabled = _sut.Apply(word);
      isEnabled.Should().Be(word);
   }
}