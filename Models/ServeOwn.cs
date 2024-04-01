using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class ServeOwn
    {
        public int Id { get; set; }
        public int? CustumarId { get; set; }
        public string? ServiceName { get; set; }
        public string? PackageName { get; set; }
        public string? Rate { get; set; }
    }
}
