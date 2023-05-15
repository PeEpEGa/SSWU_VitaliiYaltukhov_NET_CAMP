using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.RoadTypes.Interfaces;

namespace task2._2_sigma_.RoadTypes
{
    internal class CrossRoad : IRoadType
    {
        private List<Road> _roads;

        public CrossRoad(List<Road> roads)
        {
            if(roads.Count() != 2)
            {
                throw new ArgumentException("Inncorect amount of roads.");
            }
            else
            {
                _roads = new List<Road>(roads);
            }
        }

        public void ChangeTrafficLightState()
        {
            foreach (var road in _roads)
            {
                road.ChangeRoadState();
            }
        }
    }
}
