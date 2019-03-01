using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test4
    {
        //Race Conditions 
        int balance = 0;
        public void Debit(object amount)
        {
            Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            balance = balance - Convert.ToInt32(amount);
            Console.WriteLine("Account balance :" + balance);
        }

        public void Credit(object amount)
        {
            Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            balance = balance + Convert.ToInt32(amount);
            Console.WriteLine("Account balance :" + balance);
        }

        public void MainHandler()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Thread T1 = new Thread(this.Credit);
            Thread T2 = new Thread(this.Debit);
            T1.Start(10);
            T2.Start(9);
            watch.Stop();
            Console.WriteLine("Account balance :" + balance);
            Console.WriteLine("time " + watch.ElapsedMilliseconds);
        }


    }
}
