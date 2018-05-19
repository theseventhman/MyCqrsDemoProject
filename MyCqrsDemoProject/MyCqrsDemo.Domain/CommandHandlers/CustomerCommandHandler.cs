using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyCqrsDemo.Domain.Commands;
using MyCqrsDemo.Domain.Core.Bus;
using MyCqrsDemo.Domain.Core.Notifications;
using MyCqrsDemo.Domain.Events;
using MyCqrsDemo.Domain.Interfaces;
using MyCqrsDemo.Domain.Models;

namespace MyCqrsDemo.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,INotificationHandler<RegisterNewCustomerCommand>,INotificationHandler<RemoveCustomerCommand>,INotificationHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;
        public CustomerCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,ICustomerRepository customerRepository) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public Task Handle(RegisterNewCustomerCommand notification, CancellationToken cancellationToken)
        {
            return  Task.Run(() =>
            {
                Handle(notification);
            }, cancellationToken);

        }

        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            var customer = new Customer(message.Id,message.Name,message.Email,message.BirthDate);
            if (_customerRepository.GetByEmail(message.Email) != null)
            {
                _bus.RaiseEvent(
                    new DomainNotification(message.MessageType, "The Customer Email has already been taken"));
                return;
            }
            _customerRepository.Add(customer);
            if (Commit())
            {
                _bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email,
                    customer.BirthDate));
            }
        }


        public Task Handle(UpdateCustomerCommand notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Handle(notification);
            }, cancellationToken);
        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = _customerRepository.GetByEmail(message.Email);

            if (existingCustomer != null && customer.Id != existingCustomer.Id)
            {

                if (!existingCustomer.Equals(customer))
                {
                    _bus.RaiseEvent(
                        new DomainNotification(message.MessageType, "The Customer Email has already been taken"));
                    return;
                }
            }
            _customerRepository.Update(customer);
            if (Commit())
            {
                _bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email,
                    customer.BirthDate));
            }
        }




        public Task Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Handle(message);
            }, cancellationToken);
        }

        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            _customerRepository.Remove(message.Id);
            if (Commit())
            {
                _bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }



       
    }
}