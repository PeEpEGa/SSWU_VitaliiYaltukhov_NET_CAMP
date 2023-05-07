using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Contracts
{
    public class TrafficLight : ICloneable
    {
        private string _location;
        private Color _currentColor;
        private Color _previousColor;
        public static TimeSpan SwitchTime = new TimeSpan(0,0,5);

        public TrafficLight(string location, Color color)
        {
            _location = location;
            _currentColor = color;
        }

        public static void ChangeTime(int seconds)
        {
            SwitchTime = new TimeSpan(0,0,seconds);
        }

        public void ChangeColor()
        {
            var tempColor = _currentColor;
            if (_currentColor == Color.Yellow)
            {
                _currentColor = _previousColor == Color.Red ? Color.Green : Color.Red;
            }
            else
            {
                _currentColor = Color.Yellow;
            }
            _previousColor = tempColor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Traffic Light Location: {_location}");
            sb.AppendLine($"Traffic Light Color: {_currentColor}");
            return sb.ToString();
        }

        public object Clone()
        {
            return new TrafficLight(_location, _currentColor);
        }
    }

    public enum Color
    {
        Red,
        Yellow,
        Green
    }
}
