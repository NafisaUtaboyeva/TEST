using System;
using System.Collections.Generic;
using TEST.IRepositories;
using TEST.Models;
using TEST.Repositories;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            // methods
            IMethodsForAdmins methodsForAdmins = new MethodsForAdmins();
            IMethodsForUsers methodsForUsers = new MethodsForUsers();
            IMethods methods = new Methods();

            // Print Menu
            Console.WriteLine("========= W E L C O M E ===========");
        MainMenu:
            Console.WriteLine("\n1.Create an account       2.SignIn        0.Exit");
            Console.Write("-> ");

            int numOfMenu = int.Parse(Console.ReadLine());
            if (numOfMenu == 1)
                user = methods.CreateUser();
            else if (numOfMenu == 2)
                user = methods.SignIn();
            else
                goto exit;


            if (user == null)
                goto MainMenu;
            else
            {
                //Menu for Admins
                if (user.Role == Enums.UserRole.Admin)
                {
                    methodsForAdmins.Menu();
                    goto exit;
                }

                // menu for Users
                else
                {
                    methodsForUsers.Menu();
                    goto exit;
                }
            }

        exit:
            Console.WriteLine("GoodBye :)");
        }
    }
}
