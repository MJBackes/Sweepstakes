using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        private ISweepstakesManager manager;

        public MarketingFirm()
        {
            manager = GetSweepstakesManager();
        }
        public ISweepstakesManager GetSweepstakesManager()
        {
            int choice = UI.GetManagerChoice();
            switch (choice)
            {
                case 1:
                    manager = new SweepstakesStackManager();
                    return manager;
                case 2:
                    manager = new SweepstakesQueueManager();
                    return manager;
                default:
                    manager = new SweepstakesStackManager();
                    return manager;
            }
        }
        public void AddSweepstakes(Sweepstakes sweepstakes)
        {
            manager.InsertSweepstakes(sweepstakes);
        }
        public void AddSweepstakes()
        {
            manager.InsertSweepstakes(CreateSweepstakes());
        }
        public Sweepstakes CreateSweepstakes()
        {
            string name = UI.GetSweepstakesName();
            return new Sweepstakes(name);
        }
    }
}
