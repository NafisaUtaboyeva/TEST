using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCheckerWithUsers.IRepositories;
using TestCheckerWithUsers.Models;

namespace TestCheckerWithUsers.Repositories
{
    internal class MethodsForUsers : IMethodsForUsers
    {
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
