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
    
    public partial class TaskDetail
    {
        public long TaskDetailId { get; set; }
        public long StudentId { get; set; }
        public long TaskId { get; set; }
        public string TaskFileUpload { get; set; }
        public bool TaskSubmissionState { get; set; }
        public Nullable<double> TaskScore { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Task Task { get; set; }

        public TaskDetail()
        {
            this.Student = new Student();
            this.Task = new Task();
        }
    }
}
