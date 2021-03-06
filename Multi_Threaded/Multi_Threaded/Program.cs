using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;
using System.Timers;

namespace Multi_Threaded
{
    class Program
    {
        //for 1:
        static int count;
        static Random gen = new Random();


        //for 2:

        static int[] numbres = new int[1000];
        static int[] numbres1000000 = new int[1000000000];



        static public void Set100ItemsInArray(object ind)
        {

            int num = Convert.ToInt32(ind);
            for (int i = num; i <num+ 100; i++)
            {
                numbres[i] = 1;
            
            }
        }


        static public void Set100000ItemsInArray(object ind)
        {

            int num = Convert.ToInt32(ind);
            for (int i = num; i < num+10000000; i++)
            {
                numbres1000000[i] = 1;

            }
        }


        static void Main(string[] args)
        {

           
            //1.

        /*    int result;

           

            while (true)
            {
                int num1 = gen.Next(0, 10);
                int num2 = gen.Next(0, 10);

                Console.WriteLine($"calculate: {num1}*{num2}");
                Thread stoppper = new Thread(
                     () =>
                     {

                         for (count = 5; count >= -1; count--)
                       {
                          Console.WriteLine(count);
                         Thread.Sleep(1000);

                       }
                   });
                stoppper.IsBackground = true;

                stoppper.Start();
                Int32.TryParse(Console.ReadLine(), out result);
               
                int remining_time = count;
                if (remining_time >= 0 && result == num1 * num2)
                {
                    Console.WriteLine("you are great!");
                    break;

                }
                else
                    Console.WriteLine("try again");


            }
            */

            // 2.

            //create and start threads (1000):
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                new Thread(Set100ItemsInArray).Start(i * 100); 
            }

            Console.WriteLine("the time it took to thread is (1000)"+stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                numbres[i] = 1;
            }

            Console.WriteLine("the time it took to for loop is (1000):"+ stopwatch.Elapsed);






            //create and start threads (1000000):
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                new Thread(Set100000ItemsInArray).Start(i * 10000000);
            }

            stopwatch.Stop();
            Console.WriteLine("the time it took to thread is (1000000000)"+stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 1000000000; i++)
            {
                numbres1000000[i] = 1;
            }

            stopwatch.Stop();
            Console.WriteLine("the time it took to for loop is (1000000000)"+stopwatch.Elapsed);

            Console.ReadLine();



            /* the time:
             * the time it took to thread is (1000)00:00:00.0974160
the time it took to for loop is (1000):00:00:00.0000080
the time it took to thread is (1000000000)00:00:00.4602892
the time it took to for loop is (1000000000)00:00:10.4127620

            there is difrences between 1000 to 1000000000 becuse it take time to create 10 thread 
            (and i have only 2 core in the computer- it mean i think that 10 threads cant run in parallel)
             when we have short task it better to use for loop instead of threads. 
               */

        }



    }
}
