﻿using System;
using System.Collections.Generic;

namespace CustomerDomain.Models
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
