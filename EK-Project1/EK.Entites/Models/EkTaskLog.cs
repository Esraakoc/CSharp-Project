using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkTaskLog
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public string? UserId { get; set; }
        public byte Status { get; set; }
        public byte Notification {  get; set; }
        public DateTime? LogDate { get; set; }
        public string? Comment { get; set; }
        public virtual EkIssue? Issue { get; set; }
        public virtual EkUser? User { get; set; } 
    }
}
