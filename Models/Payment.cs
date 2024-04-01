using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? CustomarId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? ServiceName { get; set; }
        public string? PaymentAmmount { get; set; }
    }
}
