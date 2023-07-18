namespace Wolverine.PoC.Infrastructure.Customers.QueryHandlers;

using Wolverine.PoC.Application.Customers.Queries;

public sealed class GetPingHandler
{
    private readonly ILogger<GetPingHandler> logger;

    public GetPingHandler(ILogger<GetPingHandler> logger)
        => this.logger = logger;

    public async Task<string> HandleAsync(GetPing request, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation(nameof(GetPingHandler));

        return await Task.FromResult("PONG");
    }
}
