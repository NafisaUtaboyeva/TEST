using System;
using System.Collections.Generic;
using TestCheckerWithUsers.IRepositories;
using TestCheckerWithUsers.Models;
using Newtonsoft.Json;
using System.IO;
using TestCheckerWithUsers.Services;

namespace TestCheckerWithUsers.Repositories
{
    public class MethodsForAdmins : IMethodsForAdmins
    {
        public Test CreateTest()
        {
            Test test = new Test();
            List<Question> questionList = new List<Question>();
            Console.WriteLine("Topic of test: ");
            test.Title = Console.ReadLine();

            Console.Write("Number of questions: ");
            test.Amount = int.Parse(Console.ReadLine());

            // get questions
            for (int i = 0; i < test.Amount; i++)
            {
                Question question = new Question();
                Console.WriteLine($"Enter the {i + 1}-question:");
                question.Text = Console.ReadLine();

                Console.WriteLine("Enter variant A:");
                question.VariantA = Console.ReadLine();

                Console.WriteLine("Enter variant B:");
                question.VariantB = Console.ReadLine();

                Console.WriteLine("Enter variant C:");
                question.VariantC = Console.ReadLine();

                Console.WriteLine("Enter variant D:");
                question.VariantD = Console.ReadLine();

            enterAnswer:
                Console.Write("Enter answer: ");
                string Answer = Console.ReadLine().ToUpper();
                if (Answer != "A" && Answer != "B" &&
                    Answer != "C" && Answer != "D")
                {
                    Console.WriteLine("Sorry, but you entered an error answer");
                    goto enterAnswer;
                }
                else
                    question.Answer = Answer;
                questionList.Add(question);
            }
            test.Questions = questionList;
            
            // write the test to json file
            string json = File.ReadAllText(Constants.TestsJsonPath);
            List<Test> tests = JsonConvert.DeserializeObject<List<Test>>(json);
            tests.Add(test);
            File.WriteAllText(Constants.TestsJsonPath, JsonConvert.SerializeObject(tests));

            return test;
        }

        public void DeleteTest()
        {
            Methods method = new Methods();
            List<Test> tests = method.GetTestList();

            if(tests.Count == 0)
            {
                Console.WriteLine("You can't delete test from base, because there are not any tests in base.");
            }    
            else
            {
                foreach (Test test in tests)
                    method.AboutTest(test);
                Console.Write("Enter title of test: ");
                string title = Console.ReadLine();

                int item = -1;
                for (int i = 0; i < tests.Count; i++)
                {
                    if (tests[i].Title == title)
                    {
                        item = i;
                        break;
                    }
                }
                if (item == -1)
                    Console.WriteLine("In our base has not such title test");
                else
                    tests.RemoveAt(item);
            }
        }




        public List<User> GetListOfUsers()
        {
            string json = File.ReadAllText(Constants.UsersJsonPath);
            if (json == null)
                return null;
            else
                return JsonConvert.DeserializeObject<List<User>>(json);
        }

    }
}
