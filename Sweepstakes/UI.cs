﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UI
    {
        public delegate int PrintText(Sweepstakes sweepstakes = null);
        public delegate void PrintVoidText();
        private static int GetUserInputInt(PrintText callback, Sweepstakes sweepstakes = null)
        {
            int output;
            bool isValid;
            int maxInput = callback(sweepstakes);
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out output);
            } while (!isValid || output < 1 || output > maxInput);
            return output;
        }
        private static string GetUserInputString(PrintVoidText callback)
        {
            string output;
            callback();
            do
            {
                output = Console.ReadLine();
            } while (output == "");
            return output;
        }
        public static int GetManagerChoice()
        {
            return GetUserInputInt(PrintGetManagerText);
        }
        public static string GetSweepstakesName()
        {
            return GetUserInputString(PrintGetSweepstakesNameText);
        }
        public static int GetMainTaskInput()
        {
            return GetUserInputInt(PrintMainTaskInputText);
        }
        public static int GetManageSweepstakesInput(Sweepstakes sweepstakes)
        {
            return GetUserInputInt(PrintGetManageSweepstakesInputText,sweepstakes);
        }
        public static int ManagerIsEmpty()
        {
            return GetUserInputInt(PrintManagerIsEmptyText);
        }
        public static int ManagerIsNotEmpty()
        {
            return GetUserInputInt(PrintManagerIsNotEmptyText);
        }
        public static int GetManageExtantSweepstakesInput(Sweepstakes sweepstakes)
        {
            return GetUserInputInt(PrintExtantSweepstakesInput,sweepstakes);
        }
        public static string GetContestantFirstName()
        {
            return GetUserInputString(PrintGetContestantFirstNameText);
        }
        public static string GetContestantLastName()
        {
            return GetUserInputString(PrintGetContestantLastNameText);
        }
        public static string GetContestantEmail()
        {
            return GetUserInputString(PrintGetContestantEmailText);
        }
        private static void PrintGetContestantFirstNameText()
        {
            Console.Clear();
            Console.WriteLine("What is the contestant's first name?");
        }
        private static void PrintGetContestantLastNameText()
        {
            Console.Clear();
            Console.WriteLine("What is the contestant's last name?");
        }
        private static void PrintGetContestantEmailText()
        {
            Console.Clear();
            Console.WriteLine("What is the contestant's email?");
        }
        private static int PrintExtantSweepstakesInput(Sweepstakes sweepstakes)
        {
            Console.Clear();
            if(sweepstakes != null)
            Console.WriteLine($"Sweepstakes Name: {sweepstakes.Name}");
            Console.WriteLine("What would you like to so with this sweepstakes?");
            Console.WriteLine("1. Register contestant.");
            Console.WriteLine("2. Pick winner.");
            Console.WriteLine("3. Print contestant info.");
            Console.WriteLine("4. Back.");
            int maxInputValue = 4;
            return maxInputValue;
        }
        private static int PrintManagerIsNotEmptyText(Sweepstakes sweepstakes = null)
        {
            Console.Clear();
            Console.WriteLine("Would you like to manage an extant sweepstakes or create a new sweepstakes?");
            Console.WriteLine("1. Create Sweepstakes.");
            Console.WriteLine("2. Manage extant sweepstakes.");
            Console.WriteLine("3. Back.");
            int maxInputValue = 3;
            return maxInputValue;
        }
        private static int PrintManagerIsEmptyText(Sweepstakes sweepstakes = null)
        {
            Console.Clear();
            Console.WriteLine("There are currently no sweepstakes to manage. Create a new sweepstakes?");
            Console.WriteLine("1. Create Sweepstakes.");
            Console.WriteLine("2. Quit.");
            int maxInputValue = 2;
            return maxInputValue;
        }
        private static int PrintGetManageSweepstakesInputText(Sweepstakes sweepstakes)
        {
            Console.Clear();
            Console.WriteLine("Is this the Sweepstakes you want to manage?");
            if(sweepstakes != null)
            Console.WriteLine(sweepstakes.Name);
            Console.WriteLine("1. Manage Sweepstakes.");
            Console.WriteLine("2. Next.");
            Console.WriteLine("3. Back.");
            int maxInputValue = 3;
            return maxInputValue;
        }
        private static int PrintMainTaskInputText(Sweepstakes sweepstakes = null)
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Manage Sweepstakes.");
            Console.WriteLine("2. Quit.");
            int maxInputValue = 2;
            return maxInputValue;
        }
        private static int PrintGetManagerText(Sweepstakes sweepstakes = null)
        {
            Console.Clear();
            Console.WriteLine("How would you like to store your sweepstakes?");
            Console.WriteLine("1. Stack (First in last out).");
            Console.WriteLine("2. Queue (First in first out).");
            int maxInputValue = 2;
            return maxInputValue;
        }
        private static void PrintGetSweepstakesNameText()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Sweepstakes:");
        }
    }
}
