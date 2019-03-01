using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test1
    {
        //join
        public void GetTaskList()
        {
            Task[] tlist = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                tlist[i] = Task.Run(() =>
                {
                    Thread.Sleep(5000);
                   Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
                });
            }
            Task.WaitAll(tlist);
        }
        public void GetListWithoutTask()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
               // Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
        public void MainHandler()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            this.GetTaskList();//10135
            //this.GetListWithoutTask(); //5s*5
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            watch.Stop();
            Console.WriteLine("time " + watch.ElapsedMilliseconds);
            Console.ReadLine();
        }


    }
}
