using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TECHIS.Docs.Services;

namespace TECHIS.Docs.AzureApp
{
    public class Functions
    {
        private readonly ICustomerService _customerService;

        public Functions(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [FunctionName(nameof(ICustomerService.GetCustomer))]
        public async Task<IActionResult> GetCustomer([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (long.TryParse(req.Query["id"], out var id))
            {
                var result = await _customerService.GetCustomer(id);

                if (result==null)
                {
                    return new StatusCodeResult(404);
                }

                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult("Invalid id");
            }

        }
    }
}
