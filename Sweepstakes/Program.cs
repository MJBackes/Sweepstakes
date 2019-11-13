using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            ISweepstakesManager manager = ManagerFactory.BuildSweepstakesManager(UI.GetManagerChoice());
            MarketingFirm firm = new MarketingFirm(manager);
            firm.Run();
        }
    }
}
