namespace Calastone.TextFilter.Services;

public class FileReaderService : IFileReaderService
{
    private readonly string _directory = @"./Text/sample.txt";
    public IEnumerable<string> ReadFile()
    {
        using (var reader = new StreamReader(_directory))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}