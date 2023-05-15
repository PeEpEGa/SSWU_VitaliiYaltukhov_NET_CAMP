using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.Presenters.Interfaces;
using task2._2_sigma_.RoadTypes;
using task2._2_sigma_.RoadTypes.Interfaces;

namespace task2._2_sigma_.Presenters
{
    internal class Simulation : IPresenter
    {
        private System.Timers.Timer _timerSimulation;
        private System.Timers.Timer _timerTrafficLight;

        private List<IRoadType> _roadTypes;

        public Simulation(List<IRoadType> roadTypes, TimeOnly time)
        {
            try
            {
                _roadTypes = new List<IRoadType>(roadTypes);
                _timerSimulation = new System.Timers.Timer(time.Ticks);
                _timerTrafficLight = new System.Timers.Timer(TrafficLight.SwitchTime.TotalSeconds * 1000);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public void StartSimulation()
        {
            try
            {
                _timerSimulation.Elapsed += OnElapsed;
                _timerSimulation.Enabled = true;

                _timerTrafficLight.Elapsed += ChangeState;
                _timerTrafficLight.AutoReset = true;
                _timerTrafficLight.Enabled = true;


                Console.Write("Enter any key to finish simulation: ");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void OnElapsed(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("End of Simulation.");

            _timerSimulation.Elapsed -= OnElapsed;
            _timerTrafficLight.Elapsed -= ChangeState;

            _timerSimulation.Stop();
            _timerSimulation.Dispose();

            _timerTrafficLight.Stop();
            _timerTrafficLight.Dispose();
        }

        private void ChangeState(Object source, ElapsedEventArgs e)
        {
            foreach (var roadType in _roadTypes)
            {
                roadType.ChangeTrafficLightState();
            }
        }

        public IPresenter Action()
        {
            StartSimulation();

            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Simulation:");
        }
    }
}
