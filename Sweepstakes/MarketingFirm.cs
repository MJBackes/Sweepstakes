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

        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }
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
            if (manager.IsEmpty())
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
            bool continueRunning = true; ;
            do
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
                        continueRunning = false;
                        break;
                }
            } while (continueRunning);
        }
        private void ManageExtantSweepstakes()
        {
            bool continueRunning = true;
            do
            {
                Sweepstakes sweepstakes = manager.GetSweepstakes();
                if (sweepstakes != null)
                {
                    int input;
                    input = UI.GetManageExtantSweepstakesInput(sweepstakes);
                    switch (input)
                    {
                        case 1:
                            sweepstakes.RegisterContestant(RegisterNewContestant());
                            break;
                        case 2:
                            sweepstakes.PickWinner();
                            break;
                        case 3:
                            sweepstakes.PrintContestantInfo();
                            Console.ReadLine();
                            break;
                        default:
                            continueRunning = false;
                            break;
                    }
                }
                else
                    continueRunning = false;
            } while (continueRunning);
        }
        private Contestant RegisterNewContestant()
        {
            Contestant contestant = new Contestant();
            GetContestantInfo(contestant);
            return contestant;
        }
        private void GetContestantInfo(Contestant contestant)
        {
            contestant.FirstName = UI.GetContestantFirstName();
            contestant.LastName = UI.GetContestantLastName();
            contestant.Email = UI.GetContestantEmail();
        }
        public void Run()
        {
            MainTask();
        }
    }
}
