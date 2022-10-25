using System.IO;
using System.Net;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CleanArchitecture.AzureFunction.HttpTriggers
{
    public class AccountFunc
    {
        private readonly ILogger<AccountFunc> _logger;
        private readonly IAuthService _authenticationService;

        public AccountFunc(ILogger<AccountFunc> log, IAuthService authenticationService)
        {
            _logger = log;
            _authenticationService = authenticationService;
        }

        [FunctionName("login")]
        [OpenApiOperation(operationId: "login")]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(AuthRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(AuthResponse), Description = "The OK response")]
        public async Task<ActionResult<AuthResponse>> login(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("Login trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonConvert.DeserializeObject<AuthRequest>(requestBody);
            var result = await _authenticationService.Login(request);
            return new OkObjectResult(result);
        }

        [FunctionName("register")]
        [OpenApiOperation(operationId: "register")]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(RegistrationRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(RegistrationResponse), Description = "The OK response")]
        public async Task<ActionResult<RegistrationResponse>> register(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("Register trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonConvert.DeserializeObject<RegistrationRequest>(requestBody);
            var result = await _authenticationService.Register(request);
            return new OkObjectResult(result);
        }
    }
}

