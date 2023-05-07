using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.RoadTypes.Interfaces;

namespace task2._2_sigma_.RoadTypes
{
    internal class CrossRoad : IRoadType
    {
        private TrafficLight[] _trafficLights;

        public CrossRoad(TrafficLight[] trafficLights)
        {
            _trafficLights = new TrafficLight[trafficLights.Length];
            for (int i = 0; i < trafficLights.Length; i++)
            {
                _trafficLights[i] = (TrafficLight)trafficLights[i].Clone();
            }
        }

        public void ChangeTrafficLightState()
        {
            if(_trafficLights.Length != 4)
            {
                return;
            }

            Console.WriteLine();
            foreach (var trafficLight in _trafficLights)
            {
                Console.WriteLine(trafficLight);
                trafficLight.ChangeColor();
            }
            Console.WriteLine("\n\n");
        }
    }
}
