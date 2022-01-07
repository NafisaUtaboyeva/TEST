using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheckerWithUsers.Models;

namespace TestCheckerWithUsers.IRepositories
{
    public interface IMethods
    {
        public User CreateUser();
        public User SignIn();
        public void AboutTest(Test test);
        public List<Test> GetTestList();
        public void AboutUser(User user);
    }
}
