using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    internal class Road : ICloneable
    {
        private List<Lane> _lanes;
        private string _name;
        public Road(List<Lane> lanes, string name)
        {
            if(lanes.Any(n => n == null))
            {
                throw new ArgumentException("Lane without trafficlight.");
            }
            else
            {
                _lanes = new List<Lane>(lanes);
                _name = name;
            }
        }

        public void ChangeRoadState()
        {
            foreach (var lane in _lanes)
            {
                Console.WriteLine("\n" + this);
                lane.ChangeTraffic();
            }
        }

        public object Clone()
        {
            return new Road(_lanes, _name);
        }

        public override string ToString()
        {
            return $"Road: {_name}";
        }
    }
}
