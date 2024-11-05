namespace Calastone.TextFilter.Filters;

public class LetterFilter : WordFilter
{
    private readonly char _letter = 't';

    public override string Apply(string word)
    {
        return word.ToLower().Contains(_letter) ? string.Empty : word;
    }

    public override bool IsEnabled() => true;
}