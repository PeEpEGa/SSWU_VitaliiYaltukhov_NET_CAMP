using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.Presenters.Interfaces;
using task2._2_sigma_.RoadTypes;

namespace task2._2_sigma_.Presenters
{
    internal class Simulation : IPresenter
    {
        public IPresenter Action()
        {
            RoadSimulation roadSimulation = new RoadSimulation(SimulationTime.Time,
                new CrossRoad(new TrafficLight[] 
                {
                    new TrafficLight("North South", Color.Red),
                    new TrafficLight("South North", Color.Red),
                    new TrafficLight("East West", Color.Green),
                    new TrafficLight("East-West", Color.Green),
                }));
            roadSimulation.StartSimulation();

            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Simulation:");
        }
    }
}
