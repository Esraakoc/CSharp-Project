using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkRole
    {
        public EkRole()
        {
            EkUserRoles = new HashSet<EkUserRole>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public ICollection<EkUserRole> EkUserRoles { get; set; }
    }
}
