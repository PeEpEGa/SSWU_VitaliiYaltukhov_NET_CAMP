using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    internal class Lane : ICloneable
    {
        private ITrafficLight _traficLight;
        private string _name;
        public Lane(ITrafficLight light, string name)
        {
            _traficLight = light;
            _name = name;
        }

        public void ChangeTraffic()
        {
            Console.WriteLine(this);
            _traficLight.ChangeColor();
        }

        public object Clone()
        {
            return new Lane(_traficLight, _name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lane: {_name}");
            sb.AppendLine("Trafficlight:" + "\n" + _traficLight.ToString());

            return sb.ToString();
        }
    }
}
