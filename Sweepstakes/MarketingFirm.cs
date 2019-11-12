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
        private ISweepstakesManager GetSweepstakesManager()
        {
            int choice = UI.GetManagerChoice();
            return ManagerFactory.BuildSweepstakesManager(choice);
        }
        public void AddSweepstakes(Sweepstakes sweepstakes)
        {
            manager.InsertSweepstakes(sweepstakes);
        }
        public void AddSweepstakes()
        {
            manager.InsertSweepstakes(CreateSweepstakes());
        }
        private Sweepstakes CreateSweepstakes()
        {
            string name = UI.GetSweepstakesName();
            return new Sweepstakes(name);
        }
        private void StartUp()
        {
            manager = GetSweepstakesManager();
        }
        private void MainTask()
        {
            bool continueRunning = true;
            do
            {
                int input = UI.GetMainTaskInput();
                switch (input)
                {
                    case 1:
                        ManageSweepstakes();
                        break;
                    case 2:
                        continueRunning = false;
                        break;
                    default:
                        continue;
                }
            } while (continueRunning);
        }
        private void ManageSweepstakes()
        {
            if (!manager.HasSweepstakes())
            {
                ManageIfNoSweepstakes();
            }
            else
            {
                ManageIfSweepstakes();
            }
        }
        private void ManageIfNoSweepstakes()
        {
            int input;
            input = UI.ManagerIsEmpty();
            switch (input)
            {
                case 1:
                    AddSweepstakes();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        private void ManageIfSweepstakes()
        {
            int input;
            input = UI.ManagerIsNotEmpty();
            switch (input)
            {
                case 1:
                    AddSweepstakes();
                    break;
                case 2:
                    ManageExtantSweepstakes();
                    break;
                default:
                    break;
            }
        }
        private void ManageExtantSweepstakes()
        {
            int input;
            input = UI.GetManageExtantSweepstakesInput();
            switch (input)
            {
                case 1:
                    AddSweepstakes();
                    break;
                case 2:
                    ManageExtantSweepstakes();
                    break;
                default:
                    break;
            }
        }
        public void Run()
        {
            StartUp();
            MainTask();
        }
    }
}
