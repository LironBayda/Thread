using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Queue_and_lock
{
    class ThreadExecutor
    {
        private List<Thread> queueOfthread ;


        public ThreadExecutor()
        {
            queueOfthread = new List<Thread>();
        }
        public void Add(Thread thread)
        {
            lock (this)
            {

                queueOfthread.Add(thread);
            }
        
        }

        public void Execute()
        {
            
            lock (this)
            {

                while (queueOfthread.Count>0)
                {
                    queueOfthread.First<Thread>().Start();
                    queueOfthread.First<Thread>().Join();

                    queueOfthread.RemoveAt(0);

                
                }
            
            }

        }
    }
}
