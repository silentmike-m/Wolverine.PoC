namespace Wolverine.PoC.Application.Customers.CommandHandlers;

using Wolverine.Attributes;
using Wolverine.PoC.Application.Customers.Commands;

[RetryNow(typeof(ArgumentException), 50, 100, 250)]
public sealed class PingCustomerHandler
{
    private readonly ILogger<PingCustomerHandler> logger;

    public PingCustomerHandler(ILogger<PingCustomerHandler> logger)
        => this.logger = logger;

    public async Task HandleAsync(PingCustomer request, CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("START PONG");

        var isExceptionTime = DateTime.Now.Second % 10 != 0;

        if (isExceptionTime)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            throw new ArgumentException();
        }

        this.logger.LogInformation("END PONG");

        await Task.CompletedTask;
    }
}
