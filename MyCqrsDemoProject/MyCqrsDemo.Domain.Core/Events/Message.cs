using MediatR;

namespace MyCqrsDemo.Domain.Core.Events
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public string AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }


}