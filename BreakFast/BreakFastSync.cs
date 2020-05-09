using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BreakFast
{
    public class BreakFastSync : IBreakFast
    {
        public void MakeBreakFast()
        {
            var st = new Stopwatch();
            st.Start();

            Coffee cup = PourCoffee(1000);
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2000);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3000);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2000);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ(3);
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready! Elapsed: " + st.ElapsedMilliseconds + " ms");
        }

        private static Juice PourOJ(int v)
        {
            Task.Delay(v).Wait();
            return new Juice();
        }

        private static Toast ToastBread(int v)
        {
            Task.Delay(v).Wait();
            return new Toast();
        }

        private static void ApplyJam(Toast toast)
        {
            Task.Delay(1000).Wait();
            toast.ApplyJam();
        }

        private static void ApplyButter(Toast toast)
        {
            Task.Delay(1000).Wait();
            toast.ApplyButter();
        }

        private static Bacon FryBacon(int v)
        {
            Task.Delay(v).Wait();
            return new Bacon();
        }

        private static Egg FryEggs(int v)
        {
            Task.Delay(v).Wait();
            return new Egg();
        }

        private static Coffee PourCoffee(int v)
        {
            Task.Delay(v).Wait();
            return new Coffee();
        }
    }
}
