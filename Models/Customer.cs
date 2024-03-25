using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? AddressDetails { get; set; }
        public string? City { get; set; }
        public string? ServiceName { get; set; }
        public string? ZipCode { get; set; }
    }
}
