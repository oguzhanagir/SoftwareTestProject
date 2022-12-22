using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Models
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Mail { get; set; }
        public string? Password { get; set; }
    }
}
