using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class ManagerFactory
    {
        public static ISweepstakesManager BuildSweepstakesManager(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new SweepstakesStackManager();
                case 2:
                    return new SweepstakesQueueManager();
                default:
                    return new SweepstakesStackManager();
            }
        }
    }
}
