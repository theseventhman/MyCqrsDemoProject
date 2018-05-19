using System;
using MyCqrsDemo.Domain.Core.Commands;

namespace MyCqrsDemo.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}