using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UI
    {
        public static int GetManagerChoice()
        {
            int output;
            bool isValid;
            PrintGetManagerText();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output != 1 && output != 2);
            return output;
        }
        public static string GetSweepstakesName()
        {
            string output;
            PrintGetSweepstakesNameText();
            do
            {
                output = Console.ReadLine();
            } while (output != "");
            return output;
        }
        private static void PrintGetManagerText()
        {
            Console.Clear();
            Console.WriteLine("How would you like to store your sweepstakes?");
            Console.WriteLine("1. Stack (First in last out).");
            Console.WriteLine("2. Queue (First in first out).");
        }
        private static void PrintGetSweepstakesNameText()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Sweepstakes:");
        }
    }
}
