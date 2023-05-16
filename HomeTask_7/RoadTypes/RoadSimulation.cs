using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using task2._2_sigma_.Contracts;
using task2._2_sigma_.RoadTypes.Interfaces;

namespace task2._2_sigma_.RoadTypes
{//загалом цікаве і не стандартне проєктування. Прохання показати на занятті.
    internal class RoadSimulation
    {
        private System.Timers.Timer _timerSimulation;
        private System.Timers.Timer _timerTrafficLight;

        private TimeOnly _time;
        private IRoadType _roadType;

        public RoadSimulation(TimeOnly time, IRoadType roadType)
        {
            _time = time;
            _roadType = roadType;
        }

        public void StartSimulation()
        {
            try
            {
                _timerSimulation = new System.Timers.Timer(_time.Ticks);
                _timerSimulation.Elapsed += OnElapsed;
                _timerSimulation.Enabled = true;



                _timerTrafficLight = new System.Timers.Timer(TrafficLight.SwitchTime.TotalSeconds * 1000);
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
            _roadType.ChangeTrafficLightState();
        }
    }
}
