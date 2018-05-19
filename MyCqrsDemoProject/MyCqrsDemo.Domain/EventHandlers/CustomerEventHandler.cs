﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyCqrsDemo.Domain.Events;

namespace MyCqrsDemo.Domain.EventHandlers
{
    public class CustomerEventHandler : INotificationHandler<CustomerRegisteredEvent>,
        INotificationHandler<CustomerUpdatedEvent>,INotificationHandler<CustomerRemovedEvent>
    {
        public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CustomerUpdatedEvent notification, CancellationToken cancellationToken)
        {
           return Task.CompletedTask;
            ;
        }

        public Task Handle(CustomerRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}