namespace Calastone.TextFilter.Services;

public interface IFileReaderService
{
     IAsyncEnumerable<string> ReadFileAsync();
}