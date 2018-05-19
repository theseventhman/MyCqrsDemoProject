using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCqrsDemo.Domain.Interfaces;
using MyCqrsDemo.Domain.Models;
using MyCqrsDemo.Infra.Data.Context;

namespace MyCqrsDemo.Infra.Data.Repository
{
    public class CustomerRepository :Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(EquinoxContext context) : base(context)
        {
        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}