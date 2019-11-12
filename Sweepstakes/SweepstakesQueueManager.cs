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
            Sweepstakes current = queue.Dequeue();
            int input = UI.GetManageSweepstakesInput(current);
            bool continueRunning;
            do
            {
                switch (input)
                {
                    case 1:
                        queue.Enqueue(current);
                        continueRunning = false;
                        return current;
                    case 2:
                        queue.Enqueue(current);
                        continueRunning = true;
                        break;
                    case 3:
                        queue.Enqueue(current);
                        continueRunning = false;
                        return default;
                    default:
                        queue.Enqueue(current);
                        continueRunning = false;
                        return default;
                }
            } while (continueRunning);
            return default;
        }
        public bool HasSweepstakes()
        {
            return queue.Count != 0;
        }
    }
}
