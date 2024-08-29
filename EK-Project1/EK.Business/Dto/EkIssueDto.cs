using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Dto
{
    public class EkIssueDto
    {
        public string? TaskName { get; set; } 
        public string? Description { get; set; }
        public string? Createdby { get; set; } 
        public string? Watcher { get; set; } 
        public DateTime? FirstRecDate { get; set; }
        public double? Timestamp { get; set; }
        public DateTime? BegDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Assignedto { get; set; }
        public byte IsDeleted { get; set; } 
    }
}
 