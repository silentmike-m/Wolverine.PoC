namespace Wolverine.PoC.Infrastructure.MemoryDb.Interfaces;

using CustomerId = Guid;

internal interface IContext
{
    Dictionary<CustomerId, string> Customers { get; }
}
