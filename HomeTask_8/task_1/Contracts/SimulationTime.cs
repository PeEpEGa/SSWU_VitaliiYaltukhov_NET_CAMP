using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    public static class SimulationTime
    {
        public static TimeOnly Time { get; private set; } = new TimeOnly(20000);

        public static void ChangeSimulationTime(int seconds)
        {
            Time = new TimeOnly(seconds * 1000);
        }
    }
}
