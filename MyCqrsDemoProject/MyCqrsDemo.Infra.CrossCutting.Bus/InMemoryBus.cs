using System;
using System.Threading.Tasks;
using MediatR;
using MyCqrsDemo.Domain.Core.Bus;
using MyCqrsDemo.Domain.Core.Commands;
using MyCqrsDemo.Domain.Core.Events;

namespace MyCqrs.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus :IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}
