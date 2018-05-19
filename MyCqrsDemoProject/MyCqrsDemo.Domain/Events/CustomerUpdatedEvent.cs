using System;
using MyCqrsDemo.Domain.Core.Events;

namespace MyCqrsDemo.Domain.Events
{
    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(string customerId, string customerName, string customerEmail, DateTime customerBirthDate)
        {
            Id = customerId;
            Name = customerName;
            Email = customerEmail;
            BirthDate = customerBirthDate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}