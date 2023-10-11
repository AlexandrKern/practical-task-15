using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        async static void Flow()
        {
            var flow = Thread.CurrentThread;
            flow.Name = "flow";
            await Task.Run(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("# ");
                    Thread.Sleep(100);
                }
            });
            Console.WriteLine($"Конец работы потока {flow.Name}");
        }
        static void Main(string[] args)
        {
            var mayThread = Thread.CurrentThread;
            mayThread.Name = "mayThread";
            Thread thread = new Thread(Flow);
            thread.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.Write("$ ");
                Thread.Sleep(200);
            }
            Console.WriteLine($"Конец работы потока {mayThread.Name}");
        }
    }
}
