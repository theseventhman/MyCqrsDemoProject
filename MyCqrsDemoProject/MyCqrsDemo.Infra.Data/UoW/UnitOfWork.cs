using MyCqrsDemo.Domain.Core.Commands;
using MyCqrsDemo.Domain.Interfaces;
using MyCqrsDemo.Infra.Data.Context;

namespace MyCqrsDemo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EquinoxContext _equinoxContext;
        public UnitOfWork(EquinoxContext equinoxContext)
        {
            _equinoxContext = equinoxContext;
        }
        public void Dispose()
        {
            _equinoxContext.Dispose();
        }

        public CommandResponse Commit()
        {
           int rowsAffected =  _equinoxContext.SaveChanges();
            return new CommandResponse(rowsAffected >0);
            

           
            
        }
    }
}