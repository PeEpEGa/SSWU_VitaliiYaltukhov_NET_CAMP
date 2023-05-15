using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Child child = new Child();
            child.EventHappened += Child_EventHappened;

            child.Func();
        }
        private static void Child_EventHappened(object sender, EventArgs args)
        {
            Console.WriteLine("Event happened in child's class.");
        }
    }
}