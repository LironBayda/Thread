using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandle_and_Tasks
{
    class Program
    {
        //10.
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void ConnectToDBManualResetEvent()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Connect To DB");
            manualResetEvent.Set();


        }

        static void addCostumerManualResetEvent()
        {
            manualResetEvent.WaitOne();
            Console.WriteLine("add Customer");
        }

        static void addOrderManualResetEvent()
        {
            manualResetEvent.WaitOne();
            Console.WriteLine("add order");
        }

        static void RemoveOrderManualResetEvent()
        {
            manualResetEvent.WaitOne();
            Console.WriteLine("remove order");
        }

        static void RemoveCostumerManualResetEvent()
        {
            manualResetEvent.WaitOne();
            Console.WriteLine("remove customer");
        }


        static void ConnectToDBAutoResetEvent()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Connect To DB");
            autoResetEvent.Set();

        }

        static void addCostumerAutoResetEvent()
        {
            autoResetEvent.WaitOne();
            Console.WriteLine("add Customer");
            autoResetEvent.Set();

        }

        static void addOrderAutoResetEvent()
        {
            autoResetEvent.WaitOne();
            Console.WriteLine("add order");
            autoResetEvent.Set();

        }

        static void RemoveOrderAutoResetEvent()
        {
            autoResetEvent.WaitOne();
            Console.WriteLine("remove order");
            autoResetEvent.Set();

        }

        static void RemoveCostumerAutoResetEvent()
        {
            autoResetEvent.WaitOne();
            Console.WriteLine("remove customer");
            autoResetEvent.Set();

        }



        static void Main(string[] args)
        {
            //10
            new Thread(addCostumerManualResetEvent).Start();
            new Thread(addOrderManualResetEvent).Start();
            new Thread(RemoveCostumerManualResetEvent).Start();
            new Thread(RemoveOrderManualResetEvent).Start();
            new Thread(ConnectToDBManualResetEvent).Start();

          


            new Thread(addCostumerAutoResetEvent).Start();
            new Thread(addOrderAutoResetEvent).Start();
            new Thread(RemoveCostumerAutoResetEvent).Start();
            new Thread(RemoveOrderAutoResetEvent).Start();
            new Thread(ConnectToDBAutoResetEvent).Start();


            Console.ReadLine();

            //11

            Random random = new Random();


            Task<int> t = new Task<int>(() =>
            {
                int num = random.Next(1000, 2000);
                Thread.Sleep(num);
                return num;
            });

            t.Start();

            Console.WriteLine(t.Result);

            Task<int> t1 = new Task<int>(() =>
            {
                int num = random.Next(1000, 2000);
                Thread.Sleep(num);
                return num;
            });

            Task<int> t2 = new Task<int>(() =>
            {
                int num = random.Next(1000, 2000);
                Thread.Sleep(num);
                return num;
            });

            t1.Start();
            t2.Start();

            Task.WaitAll(t1,t2);

            //check that both of them finsh
            Console.WriteLine(t1.Status);
            Console.WriteLine(t2.Status);

            Task<int> t3 = new Task<int>(() => { 
            
                int num = random.Next(1000, 2000);
                Thread.Sleep(num);
                return num;
            });

            Task<int> t4 = new Task<int>(() =>
            {
                int num = random.Next(1000, 2000);
                Thread.Sleep(num);
                return num;
            });


            t3.Start();
            t4.Start();
            Task.WaitAny(t3, t4);


            //check which thrad is complited
            Console.WriteLine(t3.Status);
            Console.WriteLine(t4.Status);


            Console.ReadLine();

        }
    }
}
