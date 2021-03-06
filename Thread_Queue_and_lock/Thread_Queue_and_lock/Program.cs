using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Thread_Queue_and_lock
{


    

    class Program
    {


        static void Main(string[] args)
        {
            ThreadExecutor threadExecutor = new ThreadExecutor();
            threadExecutor.Add(new System.Threading.Thread(() => 
            { Console.WriteLine("hello world!"); 
                Thread.Sleep(1000); 
            })) ;
            threadExecutor.Add(new System.Threading.Thread(() => { for (int i = 1; i < 10; i++) 
                { Console.WriteLine(i);
                    Thread.Sleep(1000);
                };}));
            threadExecutor.Add(new System.Threading.Thread(() => 
            { Console.WriteLine("I am a Thread!");
                Thread.Sleep(1000);
            }));

            threadExecutor.Execute();

            Console.ReadLine();
        }
    }
}
