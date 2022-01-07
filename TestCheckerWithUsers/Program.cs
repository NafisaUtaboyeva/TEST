using System;
using System.Collections.Generic;
using TestCheckerWithUsers.IRepositories;
using TestCheckerWithUsers.Models;
using TestCheckerWithUsers.Repositories;

namespace TestCheckerWithUsers
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

            int menu1 = int.Parse(Console.ReadLine());
            if (menu1 == 1)
                user = methods.CreateUser();
            else if (menu1 == 2)
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
                AdminMenu:
                    // print admin's menu
                    Console.WriteLine("\n1.Create Test        2.Delete Test      3.Print List of Users      4.Print List of Tests    0.Exit");
                    Console.Write("-> ");

                    int menuForAdmin = int.Parse(Console.ReadLine());
                    if (menuForAdmin == 1)
                    {
                        methodsForAdmins.CreateTest();
                        goto AdminMenu;
                    }
                    else if (menuForAdmin == 2)
                    {
                        methodsForAdmins.DeleteTest();
                        goto AdminMenu;
                    }
                    else if (menuForAdmin == 3)
                    { 
                        List<User> users = methodsForAdmins.GetListOfUsers();
                        foreach (User user1 in users)
                            methods.AboutUser(user1);
                        goto AdminMenu;
                    }
                    if(menuForAdmin == 4)
                    {
                        List<Test> tests = methods.GetTestList();
                        if(tests.Count == 0)
                            Console.WriteLine("There are not any tests in our base");
                        else
                        {
                            foreach (Test test in tests)
                                methods.AboutTest(test);
                        }
                    }
                    else
                        goto exit;
                }


                // menu for Users
                else
                {
                UserMenu:
                    Console.WriteLine("\n1.Check knowledge       0.Exit");
                    Console.Write("-> ");

                    int menuForAdmin = int.Parse(Console.ReadLine());
                    if (menuForAdmin == 1)
                    {
                        List<Test> tests = methods.GetTestList();
                        if (tests.Count == 0)
                        {
                            Console.WriteLine("In our base has not any test, Sorry");
                            goto exit;
                        }
                        else
                        {
                            for(int i = 0; i < tests.Count; i++)
                            {
                                Console.WriteLine($"No: {i+1}");
                                methods.AboutTest(tests[i]);
                            }
                            Console.Write("\nChoose test number: ");
                            int numOfTest = int.Parse(Console.ReadLine());
                            if (numOfTest > tests.Count || numOfTest < 0)
                            {
                                Console.WriteLine("You entered incorrect number.");
                            }
                            else
                                methodsForUsers.SolveTest(tests[numOfTest-1]);
                            goto UserMenu;
                        }
                    }
                    else
                        goto exit;
                }
            }

        exit:
            Console.WriteLine("GoodBye :)");
        }
    }
}
