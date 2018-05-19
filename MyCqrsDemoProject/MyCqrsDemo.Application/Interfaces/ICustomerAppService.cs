using System;
using System.Collections.Generic;
using System.Linq;
using MyCqrsDemo.Application.ViewModels;
using MyCqrsDemo.Domain.Models;

namespace MyCqrsDemo.Application.Interfaces
{
    public interface ICustomerAppService
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(string id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(string id);
    }
}