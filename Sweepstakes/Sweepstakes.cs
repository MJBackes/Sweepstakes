using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes : ISubject
    {
        public Dictionary<double, Contestant> Contestants;
        public string Name { get; }
        public Contestant Winner { get; }
        private Random rng;
        public Sweepstakes(string name)
        {
            Name = name;
            Contestants = new Dictionary<double, Contestant>();
            rng = new Random();
        }
        public void Attach(IObserver observer)
        {
            RegisterContestant((Contestant)observer);
        }
        public void Detach(IObserver observer)
        {
            double key = ((Contestant)observer).RegistrationNumber;
            Contestants.Remove(key);
        }
        public void Notify()
        {
            foreach(KeyValuePair<double,Contestant> pair in Contestants)
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
            contestant.RegistrationNumber = Contestants.Count;
            Contestants.Add(contestant.RegistrationNumber, contestant);
        }
        public Contestant PickWinner()
        {
            return Contestants[rng.Next(Contestants.Count)];
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            contestant.PrintInfo();
        }
        public void Manage()
        {

        }
    }
}
