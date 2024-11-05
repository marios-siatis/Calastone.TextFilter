namespace Calastone.TextFilter.Services;

public class FileReaderService : IFileReaderService
{
    private readonly string _directory = @"./Text/sample.txt";

    public async IAsyncEnumerable<string> ReadFileAsync()
    {
        using (StreamReader reader = new StreamReader(_directory))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                yield return line;
            }
        }
    }
}