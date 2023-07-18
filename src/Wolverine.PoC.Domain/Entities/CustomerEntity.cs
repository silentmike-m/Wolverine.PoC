namespace Wolverine.PoC.Domain.Entities;

public sealed class CustomerEntity
{
    public Guid Id { get; private set; }

    public CustomerEntity(Guid id)
        => this.Id = id;
}
