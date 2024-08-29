using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkIssue
    {
        public EkIssue()
        {
            EkTaskLogs = new HashSet<EkTaskLog>();
        } 

        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? Createdby { get; set; }
        public string? Watcher { get; set; }
        public DateTime? FirstRecDate { get; set; }
        public double? Timestamp { get; set; }
        public DateTime? BegDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte IsDeleted { get; set; }

        public virtual ICollection<EkTaskLog> EkTaskLogs { get; set; }
    }
}
