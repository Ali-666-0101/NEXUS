﻿using System;
using System.Collections.Generic;

namespace NEXUS.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
