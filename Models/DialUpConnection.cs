using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class DialUpConnection
    {
        public int ConnectionId { get; set; }
        public int? CustomerId { get; set; }
        public string PakageName { get; set; } = null!;
        public int Rates { get; set; }
    }
}
