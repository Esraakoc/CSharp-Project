using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkUser
    {
        public EkUser()
        {
            EkTaskLogs = new HashSet<EkTaskLog>();
            UserRoles = new HashSet<EkUserRole>();
        }

        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<EkTaskLog> EkTaskLogs { get; set; }

        public virtual ICollection<EkUserRole> UserRoles { get; set; }
   
    }
}
 