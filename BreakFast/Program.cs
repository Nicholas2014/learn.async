using System;
using System.Threading;
using System.Threading.Tasks;

namespace BreakFast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //IBreakFast breakFast = new BreakFastSync();
            //breakFast.MakeBreakFast();

            //Console.WriteLine("Press any key to perform async version\r\n");
            //Console.ReadKey();

            //breakFast = new BreakFastAsync();
            //breakFast.MakeBreakFast();


            Console.WriteLine($"Main Begin-> {Thread.CurrentThread.ManagedThreadId}");
            FirstAsync();
            Console.WriteLine($"Main End-> {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();

        }

        private static async Task<string> FirstAsync()
        {
            Console.WriteLine($"First Begin-> {Thread.CurrentThread.ManagedThreadId}");
            var res = await Task.Delay(2000).ContinueWith(t => "First Complete");
            Console.WriteLine($"First End-> {Thread.CurrentThread.ManagedThreadId}");

            return res;
        }
    }

    internal class Juice
    {
    }

    internal class Toast
    {
        internal void ApplyButter()
        {
            Console.WriteLine("Butter has made");
        }

        internal void ApplyJam()
        {
            Console.WriteLine("Jam has made");
        }
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }
}
