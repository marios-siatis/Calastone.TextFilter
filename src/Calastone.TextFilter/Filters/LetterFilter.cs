namespace Calastone.TextFilter.Filters;

public class LetterFilter : WordFilter
{
    public override string Apply(string word)
    {
        return word.ToLower().Contains('t') ? string.Empty : word;
    }

    public override bool IsEnabled() => true;
}