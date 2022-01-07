using TestCheckerWithUsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCheckerWithUsers.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
