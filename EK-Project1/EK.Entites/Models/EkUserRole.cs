using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkUserRole
    {

        public string? UserId { get; set; } 
        public int RoleId { get; set; }

        public virtual EkUser? EkUser { get; set; } 
        public virtual EkRole? EkRole { get; set; } 
    }
}

 