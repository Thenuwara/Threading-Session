using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test3
    {
        object balance = 0;
        object point = 0;
        
        bool lockTaken = false;

        public void Credit(object amount)
        {
            Console.WriteLine(" ....... Locking the balance");
            lock (balance)
            {
                Console.WriteLine("....... Locked the balance");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("Locking the point");
               
                        lock (point)
                        {
                            Console.WriteLine("Locked the point");
                        }
                
                Console.WriteLine("Released point");
            }
            Console.WriteLine("Released balance");

        }

        public void MainHandler()
        {

            Thread T1 = new Thread(Credit);
            T1.Start(100);
            Thread.Sleep(500);
            Console.WriteLine("Locking the point");
            lock (point)
            {
                Console.WriteLine("Locked the point");
                Console.WriteLine("........ Locking the blance");
                        lock (balance)
                        {
                            Console.WriteLine(".......... Locked the balance");
                        }

                Console.WriteLine("Released the balance");
            }
            Console.WriteLine("Released the point");
            //Console.Read();

        }
    }
}
