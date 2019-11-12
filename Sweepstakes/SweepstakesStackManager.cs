using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        private Stack<Sweepstakes> stack;
        private Stack<Sweepstakes> storage;
        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes current = stack.Pop();
            int input = UI.GetManageSweepstakesInput(current);
            bool continueRunning;
            do
            {
                switch (input)
                {
                    case 1:
                        storage.Push(current);
                        continueRunning = false;
                        return current;
                    case 2:
                        storage.Push(current);
                        continueRunning = true;
                        break;
                    case 3:
                        storage.Push(current);
                        continueRunning = false;
                        return default;
                    default:
                        storage.Push(current);
                        continueRunning = false;
                        return default;
                }
            } while (continueRunning);
            return default;
        }
        public bool IsEmpty()
        {
            return stack.Count != 0;
        }
    }
}
