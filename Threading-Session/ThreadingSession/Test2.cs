using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test2
    {
        public void WithOutAsync()
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
            });
        }

        public async Task WithAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000000);
                Console.WriteLine("ID of thread : {0}", Thread.CurrentThread.ManagedThreadId);
            });
        }

        public async void MainHandler()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            this.WithOutAsync();
            Console.WriteLine(">>>>>>");
            this.WithOutAsync();
            //await WithAsync();
            //Console.WriteLine(">>>>>>");
            //await WithAsync();
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            watch.Stop();
            Console.WriteLine("time " + watch.ElapsedMilliseconds);

        }
    }
}
