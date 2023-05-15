using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    public interface ITrafficLight : ICloneable
    {
        public static TimeSpan SwitchTime { get; set; }
        void ChangeColor();
    }
}
