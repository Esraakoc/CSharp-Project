using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Dto
{
    public class IssueUpdateModel
    {
        public string? Description { get; set; }
        public string? TaskName { get; set; }
        public double Timestamp { get; set; }
    }
}
 