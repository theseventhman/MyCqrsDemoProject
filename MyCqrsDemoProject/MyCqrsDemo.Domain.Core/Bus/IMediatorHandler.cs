using System.Threading.Tasks;

namespace MyCqrsDemo.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Commands.Command;
        Task RaiseEvent<T>(T @event) where T : Events.Event;
    }
}