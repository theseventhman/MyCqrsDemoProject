using System;
using MyCqrsDemo.Domain.Core.Commands;

namespace MyCqrsDemo.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}