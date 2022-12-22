using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal? Value { get; set; }
        public User? User { get; set; }
    }
}
