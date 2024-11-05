namespace Calastone.TextFilter.Services;

public interface IFileReaderService
{
    IEnumerable<string> ReadFile();
}