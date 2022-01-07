﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheckerWithUsers.Models;

namespace TestCheckerWithUsers.IRepositories
{
    internal interface IMethodsForAdmins
    {
        public Test CreateTest();
        public List<User> GetListOfUsers();
        public void DeleteTest();
        public void Menu();

    }
}
