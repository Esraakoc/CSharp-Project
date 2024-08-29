using System;
using System.Collections.Generic;

namespace EK.Entities.Models
{
    public partial class EkComboDesc
    {
        public byte ComboId { get; set; }
        public string TableName { get; set; } = null!;
        public string FieldName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
