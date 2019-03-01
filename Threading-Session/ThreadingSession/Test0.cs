using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test0
    {
        static void FunA()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            for(int i = 0; i < 100; i++)
            {

                Console.WriteLine("A "+i);
            }

        }

        static void FunB()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("B "+i);
            }
        }

         int count1 = 0;
         int count2 = 0;
        public  void Test1()
        {
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;
            while (true)
            {
                count1++;
            }
        }
        public  void Test2()
        {
            while (true)
            {
                count2++;
            }
        }


        public void MainHandler()
        {
            Thread T1 = new Thread(Test1);
            Thread T2 = new Thread(Test2);

            T1.Start();
            T2.Start();
            T1.Priority = ThreadPriority.Highest;
            Console.WriteLine("Main thread going to sleep ...");
            Thread.Sleep(5000);
            Console.WriteLine("Count 1 =" + count1);
            Console.WriteLine("Count 2 =" + count2);
            T1.Abort();
            T2.Abort();
            
            Console.WriteLine("ID of main thread : {0}", Thread.CurrentThread.ManagedThreadId);

        }
    }
}
