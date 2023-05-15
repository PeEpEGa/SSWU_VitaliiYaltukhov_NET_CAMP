using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    public class Parent
    {
        public event EventHandler EventHappened;

        protected virtual void OnEventHappened(EventArgs args)
        {
            EventHandler handler = EventHappened;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}