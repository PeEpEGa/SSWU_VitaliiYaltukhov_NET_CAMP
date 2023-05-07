using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Presenters.Interfaces;

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
                    return new Simulation();
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
