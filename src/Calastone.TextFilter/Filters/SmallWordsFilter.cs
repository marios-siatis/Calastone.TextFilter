namespace Calastone.TextFilter.Filters;

public class SmallWordsFilter : WordFilter
{
    private readonly int _wordLengthLimit = 3; 
    public override string Apply(string word)
    {
        return word.Length < _wordLengthLimit ? string.Empty : word;
    }

    public override bool IsEnabled() => true;
}