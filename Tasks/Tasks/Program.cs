using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // 12.
           CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task<int> numSum=Task<int>.Factory.StartNew(() => {
                int sum = 0;

                int num = 1;
                while (true)
                {

                    if (cancellationTokenSource.Token.IsCancellationRequested)
                        return sum;

                    sum += num;
                    Thread.Sleep(3000);
                }
            
            },cancellationTokenSource.Token);

            Console.ReadLine();

            cancellationTokenSource.Cancel();

            Console.WriteLine($"the result from the thread is: {numSum.Result}");

            Console.ReadLine();

    


            // 13 

           
             Task task1= Task.Run(() =>
                {
                    int[] arr = new int[6];
                    int num = arr[7];
                });

            

            try
            {
               Task.WaitAll(task1);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerException.Message);
            }

            Console.ReadLine();

    }


}
}
