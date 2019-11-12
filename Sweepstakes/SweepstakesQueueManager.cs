using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        private Queue<Sweepstakes> queue;
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {
            bool continueRunning;
            do
            {
                Sweepstakes current = queue.Dequeue();
                queue.Enqueue(current);
                int input = UI.GetManageSweepstakesInput(current);
                switch (input)
                {
                    case 1:
                        return current;
                    case 2:
                        continueRunning = true;
                        break;
                    case 3:
                        return default;
                    default:
                        return default;
                }
            } while (continueRunning);
            return default;
        }
        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }
}
