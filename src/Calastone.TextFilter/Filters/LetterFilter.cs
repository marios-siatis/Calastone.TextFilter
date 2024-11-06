namespace Calastone.TextFilter.Filters;

public class LetterFilter : WordFilter
{
    private readonly char _letter = 't';

    public override string Apply(string word)
    {
        var result = word.ToLower().Contains(_letter) ? string.Empty : word;
        return base.Apply(result);
    }

    public override bool IsEnabled() => true;
}