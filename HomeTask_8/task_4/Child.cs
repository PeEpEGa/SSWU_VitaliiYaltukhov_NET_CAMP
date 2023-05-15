using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    public class Child : Parent
    {
        public void Func()
        {
            OnEventHappened(EventArgs.Empty);
        }
    }
}