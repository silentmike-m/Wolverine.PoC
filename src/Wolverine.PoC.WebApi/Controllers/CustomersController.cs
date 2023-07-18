namespace Wolverine.PoC.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Wolverine.PoC.Application.Commons;
using Wolverine.PoC.Application.Customers.Commands;
using Wolverine.PoC.Application.Customers.Queries;

[ApiController, Route("[controller]/[action]")]
public sealed class CustomersController : ApiControllerBase
{
    [HttpGet(Name = "GetPing")]
    public async Task<string> GetPing()
    {
        var request = new GetPing();

        var cancellationToken = CancellationTokenFactory.CreateToken(30);

        var result = await this.Bus.InvokeAsync<string>(request, cancellationToken);

        return await Task.FromResult(result);
    }

    [HttpPost(Name = "Ping")]
    public async Task<IActionResult> Ping()
    {
        var request = new PingCustomer();

        var cancellationToken = CancellationTokenFactory.CreateToken(30);

        await this.Bus.InvokeAsync(request, cancellationToken);

        return await Task.FromResult(this.Ok());
    }

    [HttpPost(Name = "PingWithTimeOut")]
    public async Task<IActionResult> PingWithTimeOut()
    {
        var request = new PingCustomer();

        var cancellationToken = CancellationTokenFactory.CreateToken(2);

        await this.Bus.InvokeAsync(request, cancellationToken);

        return await Task.FromResult(this.Ok());
    }
}
