using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Test6
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
                try
                {
                    Monitor.TryEnter(point, 500, ref lockTaken);
                    if (lockTaken)
                    {
                        lock (point)
                        {
                            Console.WriteLine("Locked the point");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(point);
                    }
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
                try
                {
                    Monitor.TryEnter(balance, 500, ref lockTaken);
                    if (lockTaken)
                    {
                        lock (balance)
                        {
                            Console.WriteLine(".......... Locked the balance");
                        }
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(balance);
                    }
                }
                Console.WriteLine("Released the balance");
            }
            Console.WriteLine("Released the point");
            //Console.Read();

        }
    }
}
