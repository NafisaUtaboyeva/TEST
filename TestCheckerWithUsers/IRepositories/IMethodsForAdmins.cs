using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST.IRepositories
{
    internal interface IMethodsForAdmins
    {
        public Test CreateTest();
        public List<User> GetListOfUsers();
        public void DeleteTest();
        public void Menu();

    }
}
