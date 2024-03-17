using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class ConnectionPlan
    {
        public ConnectionPlan()
        {
            CallCharges = new HashSet<CallCharge>();
        }

        public int ConnectionPlanId { get; set; }
        public int? ConnectionTypeId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int? ValidityMonths { get; set; }

        public virtual ConnectionType? ConnectionType { get; set; }
        public virtual ICollection<CallCharge> CallCharges { get; set; }
    }
}
