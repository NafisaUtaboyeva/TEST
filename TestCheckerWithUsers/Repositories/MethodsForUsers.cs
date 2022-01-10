using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.IRepositories;
using TEST.Models;

namespace TEST.Repositories
{
    internal class MethodsForUsers : IMethodsForUsers
    {
        public void Menu()
        {
            IMethods methods = new Methods();
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
                }
                else
                {
                    for (int i = 0; i < tests.Count; i++)
                    {
                        Console.WriteLine($"No: {i + 1}");
                        methods.AboutTest(tests[i]);
                    }
                    Console.Write("\nChoose test number: ");
                    int numOfTest = int.Parse(Console.ReadLine());
                    if (numOfTest > tests.Count || numOfTest < 0)
                    {
                        Console.WriteLine("You entered incorrect number.");
                    }
                    else
                        SolveTest(tests[numOfTest - 1]);
                    goto UserMenu;
                }
            }
        }


        public void SolveTest(Test test)
        {
            int numberOfCorrectAnswers = 0;
            for (int i = 0; i < test.Amount; i++)
            {
                // print test
                Console.WriteLine($"{i + 1}.{test.Questions[i].Text}");
                Console.WriteLine($"A){test.Questions[i].VariantA}");
                Console.WriteLine($"B){test.Questions[i].VariantB}");
                Console.WriteLine($"C){test.Questions[i].VariantC}");
                Console.WriteLine($"D){test.Questions[i].VariantD}");

                // get answer
            enterAnswer:
                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer != "A" && userAnswer != "B" &&
                    userAnswer != "C" && userAnswer != "D")
                {
                    Console.WriteLine("Sorry, but you entered an error answer");
                    goto enterAnswer;
                }
                else
                {
                    if (userAnswer == test.Questions[i].Answer)
                        numberOfCorrectAnswers++;
                }
                
            }

            // total correct and incorrect answers
            Console.WriteLine("=======================");
            Console.WriteLine($"Correct answers: {numberOfCorrectAnswers}\n" +
                              $"Incorrect answers: {test.Amount - numberOfCorrectAnswers}\n" +
                              $"Total: {numberOfCorrectAnswers * 100 / test.Amount}%");
        }
    }
}
