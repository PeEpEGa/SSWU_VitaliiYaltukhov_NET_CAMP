using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    internal class TurningTrafficLight : ITrafficLight
    {
        private string _location;
        private Color _currentColor;
        private Color _previousColor;
        private Color _turningColor;

        public static TimeSpan SwitchTime { get; set; } = new TimeSpan(0, 0, 5);

        public TurningTrafficLight(string location, Color color)
        {
            _location = location;
            _currentColor = color;
        }

        public static void ChangeTime(int seconds)
        {
            SwitchTime = new TimeSpan(0, 0, seconds);
        }

        public void ChangeColor()
        {
            var tempColor = _currentColor;
            if (_currentColor == Color.Yellow)
            {
                _currentColor = _previousColor == Color.Red ? Color.Green : Color.Red;
                _turningColor = Color.Green;
            }
            else
            {
                _currentColor = Color.Yellow;
                _turningColor = Color.Yellow;
            }
            _previousColor = tempColor;
        }

        public object Clone()
        {
            return new TurningTrafficLight(_location, _currentColor);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Traffic Light Location: {_location}");
            sb.AppendLine($"Traffic Light Color: {_currentColor}");
            sb.AppendLine($"Traffic Light Turning Color: {_turningColor}");
            return sb.ToString();
        }
    }
}
