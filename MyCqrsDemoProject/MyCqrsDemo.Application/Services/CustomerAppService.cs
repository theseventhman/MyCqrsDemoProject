using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyCqrsDemo.Application.Interfaces;
using MyCqrsDemo.Application.ViewModels;
using MyCqrsDemo.Domain.Commands;
using MyCqrsDemo.Domain.Core.Bus;
using MyCqrsDemo.Domain.Interfaces;

namespace MyCqrsDemo.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bus = bus;
        }
        public void Register(CustomerViewModel customerViewModel)
        {
            RegisterNewCustomerCommand registerNewCustomerCommand =
                _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            _bus.SendCommand(registerNewCustomerCommand);

        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>();
        }

        public CustomerViewModel GetById(string id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            UpdateCustomerCommand updateCustomerCommand =
                _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            _bus.SendCommand(updateCustomerCommand);
        }

        public void Remove(string id)
        {
            var removeCustomerCommand = new RemoveCustomerCommand(id);
            _bus.SendCommand(removeCustomerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}