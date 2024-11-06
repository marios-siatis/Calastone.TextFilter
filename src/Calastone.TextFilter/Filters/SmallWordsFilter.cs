using System.Text.RegularExpressions;

namespace Calastone.TextFilter.Filters;

public class SmallWordsFilter : WordFilter
{
    private readonly int _wordLengthLimit = 3; 
    public override string Apply(string word)
    {
        var sanitisedWord = Regex.Replace(word, "[^a-zA-Z]", "");
        
        var result= sanitisedWord.Length < _wordLengthLimit ? string.Empty : word;
        return base.Apply(result);
    }

    public override bool IsEnabled() => true;
}