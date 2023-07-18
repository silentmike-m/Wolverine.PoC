namespace Wolverine.PoC.Infrastructure.MemoryDb.Services;

using Wolverine.PoC.Infrastructure.MemoryDb.Interfaces;
using CustomerId = Guid;

internal sealed record Context : IContext
{
    public Dictionary<CustomerId, string> Customers { get; private set; }

    public Context()
        => this.Customers = new Dictionary<CustomerId, string>();
}
