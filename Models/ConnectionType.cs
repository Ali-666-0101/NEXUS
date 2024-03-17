using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class ConnectionType
    {
        public ConnectionType()
        {
            ConnectionPlans = new HashSet<ConnectionPlan>();
        }

        public int ConnectionTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ConnectionPlan> ConnectionPlans { get; set; }
    }
}
