using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class CallCharge
    {
        public int CallChargeId { get; set; }
        public int? PlanId { get; set; }
        public string CallType { get; set; } = null!;
        public decimal Charge { get; set; }

        public virtual ConnectionPlan? Plan { get; set; }
    }
}
