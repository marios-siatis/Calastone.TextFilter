namespace Calastone.TextFilter.Filters;

public abstract class WordFilter : IWordFilter
{
    public virtual bool IsEnabled()
    {
        return false;
    }

    public virtual string Apply(string word)
    {
        return "";
    }
}