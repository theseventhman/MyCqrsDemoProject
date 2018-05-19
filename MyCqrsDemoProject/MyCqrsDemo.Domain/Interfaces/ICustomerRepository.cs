using MyCqrsDemo.Domain.Models;

namespace MyCqrsDemo.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}