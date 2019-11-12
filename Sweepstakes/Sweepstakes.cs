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
                    NotifyWinner();
                }
                else
                {
                    NotifyNonWinningContestant();
                }
            }
        }
        private void NotifyWinner()
        {

        }
        private void NotifyNonWinningContestant()
        {

        }
        public void RegisterContestant(Contestant contestant)
        {
            contestant.RegistrationNumber = new Guid();
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
            foreach (KeyValuePair<double, Contestant> contestant in Contestants)
            {
                contestant.Value.PrintInfo();
            }
        }
        public void Manage()
        {

        }
    }
}
