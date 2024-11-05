using Calastone.TextFilter.Filters;

namespace Calastone.TextFilter.Services;

public class TextFilterService : ITextFilterService
{
    private readonly IFileReaderService _fileReaderService;

    public TextFilterService(IFileReaderService fileReaderService)
    {
        _fileReaderService = fileReaderService;
    }

    public async IAsyncEnumerable<string> Process()
    {
        var chainedFilters = new VowelFilter();
        var smallWordsFilter = new SmallWordsFilter();
        var letterFilter = new LetterFilter();

        chainedFilters
            .SetNext(smallWordsFilter)
            .SetNext(letterFilter);

        await foreach (var line in _fileReaderService.ReadFileAsync())
        {
            var clearedLine = line;
            foreach (var word in line.Split(' '))
            {
                yield return chainedFilters.Apply(word);
            }

            yield return string.Empty;
        }
    }
}