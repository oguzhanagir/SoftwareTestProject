﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }

        public User? User { get; set; }
    }
}
