using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinihuronBackend.DTO
{
    public class Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }        
    }
}