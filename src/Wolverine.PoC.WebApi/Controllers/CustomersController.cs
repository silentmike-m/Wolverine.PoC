﻿namespace Wolverine.PoC.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Wolverine.PoC.Application.Customers.Commands;
using Wolverine.PoC.Application.Customers.Queries;

[ApiController, Route("[controller]/[action]")]
public sealed class CustomersController : ApiControllerBase
{
    [HttpGet(Name = "GetPing")]
    public async Task<string> GetPing(CancellationToken cancellationToken = default)
    {
        var request = new GetPing();

        var result = await this.Bus.InvokeAsync<string>(request, cancellationToken);

        return await Task.FromResult(result);
    }

    [HttpPost(Name = "Ping")]
    public async Task<IActionResult> Ping(CancellationToken cancellationToken = default)
    {
        var request = new PingCustomer();

        await this.Bus.InvokeAsync(request, cancellationToken);

        return await Task.FromResult(this.Ok());
    }

    [HttpPost(Name = "PingWithTimeOut")]
    public async Task<IActionResult> PingWithTimeOut(CancellationToken cancellationToken = default)
    {
        var request = new PingCustomer();

        await Task.Delay(TimeSpan.FromSeconds(10));

        await this.Bus.InvokeAsync(request, cancellationToken);

        return await Task.FromResult(this.Ok());
    }
}
