namespace Calastone.TextFilter.Filters;

public abstract class WordFilter : IWordFilter
{
    private IWordFilter _nextFilter;

    public IWordFilter SetNext(IWordFilter nextFilter)
    {
        _nextFilter = nextFilter;
        return nextFilter;
    }

    public virtual bool IsEnabled()
    {
        return false;
    }

    public virtual string Apply(string word)
    {
        if (_nextFilter != null)
        {
            return _nextFilter.Apply(word);
        }

        return word;
    }
}