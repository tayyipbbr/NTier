﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities.Models
{
    public sealed class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product> Products { get; set; }    
    }
}
