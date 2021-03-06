using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_events1
{
    class AtomicCalculator
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Func<int> GetNumberFromUser { get; set; }
        public Action MenuPrinter { get; set; }
        public Func<int> GetUserChoice { get; set; }
        public Func<int, int, int, double> Calculate { get; set; }
        public Action<double> ResultPrinter { get; set; }

        public void Run()
        {
            X = GetNumberFromUser.Invoke();
            Y = GetNumberFromUser.Invoke();
            MenuPrinter.Invoke();
            int userChoise = GetUserChoice.Invoke();
            ResultPrinter.Invoke(Calculate.Invoke(X, Y, userChoise));

     



        }
    }
}
