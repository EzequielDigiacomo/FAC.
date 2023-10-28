using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.Controladora.DTOs.LoginUser
{
    public class LoginUserCrearDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public string Rol { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
