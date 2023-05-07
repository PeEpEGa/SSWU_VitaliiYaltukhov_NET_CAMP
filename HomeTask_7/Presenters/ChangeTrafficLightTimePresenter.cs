using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.Presenters.Interfaces;

namespace task2._2_sigma_.Presenters
{
    internal class ChangeTrafficLightTimePresenter : IPresenter
    {
        public IPresenter Action()
        {
            int seconds = -1;
            try
            {
                do
                {
                    seconds = Int32.Parse(Console.ReadLine());
                } while (seconds < 1);
                TrafficLight.ChangeTime(seconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Please enter to continue...");
            Console.ReadKey();
            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();
            Console.Write("Please enter time for trafficlight to switch (in seconds): ");
        }
    }
}
