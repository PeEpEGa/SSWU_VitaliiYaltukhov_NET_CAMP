using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.Presenters.Interfaces;
using task2._2_sigma_.RoadTypes;
using task2._2_sigma_.RoadTypes.Interfaces;

namespace task2._2_sigma_.Presenters
{
    internal class MainMenuPresenter : IPresenter
    {
        public IPresenter Action()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new Simulation(new List<IRoadType>() { 
                    new CrossRoad(new List<Road>
                    {
                        new Road(
                            new List<Lane>
                            {
                                new Lane(new TrafficLight("North South", Color.Red), "lane1"),
                                new Lane(new TrafficLight("South North", Color.Red), "lane2")
                            }, "road1"),
                        new Road(
                            new List<Lane>
                            {
                                new Lane(new TrafficLight("East West", Color.Green), "lane3"),
                                new Lane(new TrafficLight("East-West", Color.Green), "lane4")
                            }, "road2")
                    })
                    }
                    , SimulationTime.Time);
                case ConsoleKey.D2:
                    return new ChangeTrafficLightTimePresenter();
                case ConsoleKey.D3:
                    return new ChangeSimulationTimePresenter();
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("Road Simulator");
            Console.WriteLine();
            Console.WriteLine("1 - Start Simulation");
            Console.WriteLine("2 - Change Switch Time");
            Console.WriteLine("3 - Set Time For Simulation");
            Console.WriteLine("0 - Exit");
        }
    }
}
