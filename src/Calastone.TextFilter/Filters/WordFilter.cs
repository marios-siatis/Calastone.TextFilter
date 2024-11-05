namespace Calastone.TextFilter.Filters;

public abstract class WordFilter : IWordFilter
{
    public virtual bool IsEnabled()
    {
        return false;
    }

    public abstract string Apply(string word);
}