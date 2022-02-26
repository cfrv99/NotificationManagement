using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR.NotificationHandler.Commons
{
    public class Notification
    {
        public string ToConnectionId { get; set; }
        public string FromConnectionId { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; } = NotificationType.Success
    }
    public enum NotificationType
    {
        Success,
        Warning,
        Pending
    }
}
