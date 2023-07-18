namespace Wolverine.PoC.Domain.Repositories;

using Wolverine.PoC.Domain.Entities;

public interface ICustomerRepository
{
    public CustomerEntity? Get(Guid id);
    IEnumerable<CustomerEntity> GetAll();
    public void Save(CustomerEntity customer);
}
