namespace Calastone.TextFilter.Services;

public interface ITextFilterService
{
    IAsyncEnumerable<string> Process();
}