using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_events1
{
    class SimpleCalculator
    {
        public int NumberGetter()
        {
            int num=0;
            Console.WriteLine("enter positive number");

            while (num <= 0)
            {
                Int32.TryParse(Console.ReadLine(), out num);

            }

            return num;
        }

        public void PrintMenu()
        {

            Console.WriteLine("choose one from the followong action");
            Console.WriteLine("1. addition");
            Console.WriteLine("2. subtraction");
            Console.WriteLine("3. multiplication");
            Console.WriteLine("4. division");





        }
        public int GetUserChoice()
        {
            int num = 0;
            Console.WriteLine("enter option (number between 1 to 4)");

            while (num <= 0)
            {
                Int32.TryParse(Console.ReadLine(), out num);

            }

            return num;
        }

        public double Calculate(int num1, int num2,int option)
        {
            double result=0;

            switch (option)
            {
                case 1:
                    result=num1 + num2;
                    break;
                case 2:
                    result = num1 - num2;
                    break;
                case 3:
                    result = num1 * num2;
                    break;
                case 4:
                    result = num1 / num2;
                    break;


            }

            return result;



        }

       public void PrintResultNicely(double num)
        {

            Console.WriteLine("the result is: " + num);
        
        }

    }
}
