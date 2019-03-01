using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSession
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 1;
            while (c==1) {
                Console.WriteLine("Program > Enter Number : ");
                int val = Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 0:
                        new Test0().MainHandler();// Thread
                        break;
                    case 1:
                        new Test1().MainHandler();// race condition
                        break;
                    case 2:
                        new Test2().MainHandler();// avoid race condition
                        break;
                    case 3:
                        new Test3().MainHandler();// DeadLock
                        break;
                    case 4:
                        new Test4().MainHandler(); // Parallel programming
                        break;
                    case 5:
                        new Test5().MainHandler(); // Parallel programming
                        break;
                    case 6:
                        new Test6().MainHandler(); // Avoid deadlock
                        break;
                    default:
                        c = 0;
                        break;
                }
            }
            
        }
    }
}
