//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public long NotificationId { get; set; }
        public string NotificationName { get; set; }
        public System.DateTime NotificationDateCreate { get; set; }
        public System.DateTime NotificationCreatorName { get; set; }
        public string NotificationContent { get; set; }
        public long NotificationType { get; set; }
        public Nullable<long> CourseId { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
