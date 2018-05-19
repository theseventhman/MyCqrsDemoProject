using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MyCqrsDemo.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }
        public object Handle(DomainNotification notification)
        {
           _notifications.Add(notification);
            return null;
        }

        public void NewHandle(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
           _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            //TaskCompletionSource<object> completionSource = new TaskCompletionSource<object>();
            //completionSource.SetResult(Handle(notification));
            //return completionSource.Task;

            _notifications.Add(notification);
            return Task.CompletedTask;
            ;

            //return Task.Run(() =>
            //{
            //    _notifications.Add(notification);
            //}, cancellationToken);
        }

        private Task HandleNew(DomainNotification notification, CancellationToken cancellationToken)
        {
            
            return Task.Factory.StartNew(() =>
            {
                _notifications.Add(notification);
            }, cancellationToken,TaskCreationOptions.DenyChildAttach,  TaskScheduler.Default);
        }
    }
}