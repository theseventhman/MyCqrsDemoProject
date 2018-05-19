using System;
using MyCqrsDemo.Domain.Core.Events;

namespace MyCqrsDemo.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
       public string DomainNotificationId { get; private set; }
        
       public string Key { get; private set; }

       public string Value { get; private set; }

       public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid().ToString();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}