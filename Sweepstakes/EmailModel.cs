using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class EmailModel
    {
        public string FromDisplayName { get; set; }
        public string FromEmailAddress { get; set; }
        public string ToName { get; set; }
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public EmailModel(string firstName, string lastName, string emailAdress, string sweepstakesName, bool isWinner)
        {
            ToName = $"{firstName} {lastName}";
            ToEmailAddress = emailAdress;
            FromDisplayName = $"{sweepstakesName}";
            FromEmailAddress = "";
            Subject = $"Re: The {sweepstakesName} Sweepstakes.";
            if (isWinner)
                Message = "You Won!";
            else
                Message = "You did not win.";
        }
    }
}
