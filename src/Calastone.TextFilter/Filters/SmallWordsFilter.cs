using System.Text.RegularExpressions;
using Calastone.TextFilter.Extensions;

namespace Calastone.TextFilter.Filters;

public class SmallWordsFilter : WordFilter
{
    private readonly int _wordLengthLimit = 3; 
    public override string Apply(string word)
    {
        var result= word.RemoveNonAlphabetic().Length < _wordLengthLimit ? string.Empty : word;
        return base.Apply(result);
    }

    public override bool IsEnabled() => true;
}