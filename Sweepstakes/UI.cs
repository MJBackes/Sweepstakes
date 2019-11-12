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
            int maxInput = PrintGetManagerText();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
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
        public static int GetMainTaskInput()
        {
            int output;
            bool isValid;
            int maxInput = PrintMainTaskInputText();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
            return output;
        }
        public static int GetManageSweepstakesInput(Sweepstakes sweepstakes)
        {
            int output;
            bool isValid;
            int maxInput = PrintGetManageSweepstakesInputText(sweepstakes);
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
            return output;
        }
        public static int ManagerIsEmpty()
        {
            int output;
            bool isValid;
            int maxInput = PrintManagerIsEmptyText();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
            return output;
        }
        public static int ManagerIsNotEmpty()
        {
            int output;
            bool isValid;
            int maxInput = PrintManagerIsNotEmptyText();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
            return output;
        }
        public static int GetManageExtantSweepstakesInput()
        {
            int output;
            bool isValid;
            int maxInput = PrintExtantSweepstakesInput();
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid && output > 0 && output <= maxInput);
            return output;
        }
        private static int PrintExtantSweepstakesInput()
        {
            Console.Clear();
            Console.WriteLine("What would you like to so with this sweepstakes?");
            Console.WriteLine("1. Register contestant.");
            Console.WriteLine("2. Pick winner.");
            Console.WriteLine("3. Print contestant info.");
            Console.WriteLine("4. Quit.");
            return 4;
        }
        private static int PrintManagerIsNotEmptyText()
        {
            Console.Clear();
            Console.WriteLine("Would you like to manage an extant sweepstakes or create a new sweepstakes?");
            Console.WriteLine("1. Create Sweepstakes.");
            Console.WriteLine("2. Manage extant sweepstakes.");
            Console.WriteLine("3. Quit.");
            return 3;
        }
        private static int PrintManagerIsEmptyText()
        {
            Console.Clear();
            Console.WriteLine("There are currently no sweepstakes to manage. Create a new sweepstakes?");
            Console.WriteLine("1. Create Sweepstakes.");
            Console.WriteLine("2. Quit.");
            return 2;
        }
        private static int PrintGetManageSweepstakesInputText(Sweepstakes sweepstakes)
        {
            Console.Clear();
            Console.WriteLine("Is this the Sweepstakes you want to manage?");
            Console.WriteLine(sweepstakes.Name);
            Console.WriteLine("1. Manage Sweepstakes.");
            Console.WriteLine("2. Next.");
            Console.WriteLine("3. Quit.");
            return 3;
        }
        private static int PrintMainTaskInputText()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Manage Sweepstakes.");
            Console.WriteLine("2. Quit.");
            return 2;
        }
        private static int PrintGetManagerText()
        {
            Console.Clear();
            Console.WriteLine("How would you like to store your sweepstakes?");
            Console.WriteLine("1. Stack (First in last out).");
            Console.WriteLine("2. Queue (First in first out).");
            return 2;
        }
        private static void PrintGetSweepstakesNameText()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Sweepstakes:");
        }
    }
}
