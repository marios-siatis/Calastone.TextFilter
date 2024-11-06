using Calastone.TextFilter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Calastone.TextFilter.Functions;

public class FilterTextHttpTrigger
{
    private readonly ILogger<FilterTextHttpTrigger> _logger;
    private readonly ITextFilterService _textFilterService;

    public FilterTextHttpTrigger(ILogger<FilterTextHttpTrigger> logger, ITextFilterService textFilterService)
    {
        _logger = logger;
        _textFilterService = textFilterService;
    }

    [Function("FilterTextHttpTrigger")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        _logger.LogInformation("");
        _logger.LogInformation("=====================  Output Text ===========================");
        await foreach (var word in _textFilterService.Process())
        {
            Console.Write(string.IsNullOrEmpty(word) ? string.Empty : word + " ");
        }
        _logger.LogInformation("");
        _logger.LogInformation("==============================================================");
        _logger.LogInformation("");
        Console.WriteLine();
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}