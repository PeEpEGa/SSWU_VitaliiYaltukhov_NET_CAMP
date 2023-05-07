using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._2_sigma_.Presenters.Interfaces
{
    public interface IPresenter
    {
        void Show();
        IPresenter Action();
    }
}
