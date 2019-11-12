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
            storage = new Stack<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {
            bool continueRunning;
            Sweepstakes current;
            do
            {
                if (IsEmpty())
                    ReturnToStack(storage);
                current = stack.Pop();
                storage.Push(current);
                int input = UI.GetManageSweepstakesInput(current);
                switch (input)
                {
                    case 1:
                        ReturnToStack(storage);
                        return current;
                    case 2:
                        continueRunning = true;
                        break;
                    case 3:
                        continueRunning = false;
                        break;
                    default:
                        continueRunning = false;
                        break;
                }
            } while (continueRunning);
            ReturnToStack(storage);
            return default;
        }
        private void ReturnToStack(Stack<Sweepstakes> tempStack)
        {
            foreach(Sweepstakes sweepstakes in tempStack)
            {
                stack.Push(sweepstakes);
            }
            tempStack.Clear();
        }
        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }
}
