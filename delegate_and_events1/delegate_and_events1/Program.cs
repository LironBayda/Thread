using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_events1
{
    class Program
    {
        static void Main(string[] args)
        {
            AtomicCalculator atomicCalculator = new AtomicCalculator();
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            atomicCalculator.GetNumberFromUser = simpleCalculator.NumberGetter;
            atomicCalculator.MenuPrinter = simpleCalculator.PrintMenu;
            atomicCalculator.GetUserChoice = simpleCalculator.GetUserChoice;
            atomicCalculator.Calculate = simpleCalculator.Calculate;
            atomicCalculator.ResultPrinter = simpleCalculator.PrintResultNicely;

            atomicCalculator.Run();

            Console.ReadLine();
        }
    }
}
