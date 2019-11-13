using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes : ISubject
    {
        public Dictionary<Guid, Contestant> Contestants;
        public string Name { get; }
        private Contestant winner;
        public Contestant Winner { get => winner; }
        private Random rng;
        public Sweepstakes(string name)
        {
            Name = name;
            Contestants = new Dictionary<Guid, Contestant>();
            rng = new Random();
        }
        public void Notify()
        {
            foreach(KeyValuePair<Guid,Contestant> pair in Contestants)
            {
                if(pair.Value == Winner)
                {
                    NotifyWinner(pair.Value);
                }
                else
                {
                    NotifyNonWinningContestant(pair.Value);
                }
            }
        }
        private async void NotifyWinner(Contestant contestant)
        {
            EmailModel model = new EmailModel(
                contestant.FirstName,
                contestant.LastName,
                contestant.Email,
                Name,
                true);
            await EmailService.SendEmail(model);
        }
        private async void NotifyNonWinningContestant(Contestant contestant)
        {
            EmailModel model = new EmailModel(
                contestant.FirstName,
                contestant.LastName,
                contestant.Email,
                Name,
                false);
            await EmailService.SendEmail(model);
        }
        public void RegisterContestant(Contestant contestant)
        {
            contestant.RegistrationNumber = Guid.NewGuid();
            Contestants.Add(contestant.RegistrationNumber, contestant);
        }
        public Contestant PickWinner()
        {
            int randomCounter = 0;
            int target = rng.Next(Contestants.Count);
            foreach(KeyValuePair<Guid,Contestant> pair in Contestants)
            {
                if (randomCounter == target)
                    winner = pair.Value;
                randomCounter++;
            }
            Notify();
            return Winner;
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            contestant.PrintInfo();
        }
        public void PrintContestantInfo()
        {
            foreach (KeyValuePair<Guid, Contestant> contestant in Contestants)
            {
                contestant.Value.PrintInfo();
            }
        }
    }
}
