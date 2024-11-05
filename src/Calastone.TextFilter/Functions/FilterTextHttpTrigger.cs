using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Calastone.TextFilter.Functions;

public class FilterTextHttpTrigger
{
    private readonly ILogger<FilterTextHttpTrigger> _logger;

    public FilterTextHttpTrigger(ILogger<FilterTextHttpTrigger> logger)
    {
        _logger = logger;
    }

    [Function("FilterTextHttpTrigger")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}