using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheckerWithUsers.Models;

namespace TestCheckerWithUsers.IRepositories
{
    internal interface IMethodsForUsers
    {
        public void SolveTest(Test test);
        public void Menu();

    }
}
