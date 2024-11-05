namespace Calastone.TextFilter.Filters;

public interface IWordFilter
{
    bool IsEnabled();
    string Apply(string text);
    IWordFilter SetNext(IWordFilter text);
}