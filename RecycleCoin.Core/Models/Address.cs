using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Value { get; set; }

        public List<User>? Users { get; set; }
    }
}
