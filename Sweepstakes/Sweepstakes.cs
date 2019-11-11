using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        public Dictionary<double, Contestant> Contestants;
        public string Name { get; }
        private Random rng;
        public Sweepstakes(string name)
        {
            Name = name;
            Contestants = new Dictionary<double, Contestant>();
            rng = new Random();
        }
        public void RegisterContestant(Contestant contestant)
        {
            Contestants.Add(Contestants.Count, contestant);
        }
        public Contestant PickWinner()
        {
            return Contestants[rng.Next(Contestants.Count)];
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            contestant.PrintInfo();
        }
    }
}
