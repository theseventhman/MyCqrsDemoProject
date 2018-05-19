using MyCqrsDemo.Domain.Core.Events;

namespace MyCqrsDemo.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(string messageId)
        {
            Id = messageId;
        }

        public string Id { get; }
    }
}