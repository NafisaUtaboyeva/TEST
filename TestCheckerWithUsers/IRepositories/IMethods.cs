using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST.IRepositories
{
    internal interface IMethods
    {
        public User CreateUser();
        public User SignIn();
        public void AboutTest(Test test);
        public List<Test> GetTestList();
        public void AboutUser(User user);
    }
}
