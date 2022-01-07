using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheckerWithUsers.IRepositories;
using TestCheckerWithUsers.Enums;
using TestCheckerWithUsers.Models;
using TestCheckerWithUsers.Services;
using Newtonsoft.Json;

namespace TestCheckerWithUsers.Repositories
{
    public class Methods : IMethods
    {
        public void AboutTest(Test test)
        {
            Console.WriteLine($"About: {test.Title}");
            Console.WriteLine($"Number of questions: {test.Amount}");
        }

        public void AboutUser(User user)
        {
            Console.WriteLine($"FirstName: {user.FirstName}\n" +
                $"LastName: {user.LastName}\n" + 
                $"Role: {user.Role}\n");
        }

        public User CreateUser()
        {
            User user = new User();

            //Read all informations about User
            Console.Write("Enter FirstName: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            user.LastName = Console.ReadLine();

            Console.WriteLine("Enter role:\n1.User       2. Admin");
            int roleNum = int.Parse(Console.ReadLine());
            if (roleNum == 1)
                user.Role = UserRole.User;
            else
            {
                Console.Write("Enter admin's password: ");
                string password = Console.ReadLine();
                if (password == Constants.PasswordForAdmins)
                    user.Role = UserRole.Admin;
                else
                {
                    Console.WriteLine("You entered an arror password, You are not Admin");
                    user.Role = UserRole.User;
                }
            }

            Console.Write("Enter Login: ");
            user.Login = Console.ReadLine();

            Console.Write("Enter password: ");
            user.Password = Console.ReadLine();

            // write the test to json file
            string json = File.ReadAllText(Constants.UsersJsonPath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            users.Add(user); 
            File.WriteAllText(Constants.UsersJsonPath, JsonConvert.SerializeObject(users));

            return user;
        }




        public List<Test> GetTestList()
        {
            string json = File.ReadAllText(Constants.TestsJsonPath);
            if(json == null)    
                return null;
            else
                return JsonConvert.DeserializeObject<List<Test>>(json);
        }




        public User SignIn()
        {
            MethodsForAdmins method = new MethodsForAdmins();
            List<User> users = method.GetListOfUsers();
            if(users.Count == 0)
            {
                Console.WriteLine("You can not sig in, because there are not any accounts in our base.");
                Console.WriteLine("Please create an account.");
                return null;
            }
            else
            {
                Console.Write("Enter your Login: ");
                string login = Console.ReadLine();
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Login == login)
                    {
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();
                        if (users[i].Password == password)
                            return users[i];
                        else
                        {
                            Console.WriteLine("An error password(");
                            return null;
                        }
                    }
                }
                Console.WriteLine("You entered an arror login(");
                return null;
            }
        }
    }
}
