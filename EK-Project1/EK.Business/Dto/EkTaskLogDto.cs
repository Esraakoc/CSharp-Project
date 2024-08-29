using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Dto
{
    public class EkTaskLogDto
    { 
        public int TaskId { get; set; }
        public string UserId { get; set; } = null!;
        public byte Status { get; set; }
        public byte Notification { get; set; }
        public string? Comment { get; set; }
        public DateTime? LogDate { get; set; }
    } 
}
 