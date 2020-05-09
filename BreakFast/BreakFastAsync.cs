using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreakFast
{
    public class BreakFastAsync : IBreakFast
    {
        public async void MakeBreakFast()
        {
            var st = new Stopwatch();
            st.Start();

            var cup = PourCoffee(1000);
            Console.WriteLine($"coffee is ready({Thread.CurrentThread.ManagedThreadId})");

            var eggsTask = FryEggsAsync(2000);
            var baconTask = FryBaconAsync(3000);
            var toastTask = MakeToastWithButterAndJamAsync(2000);

            var toast = await toastTask;
            Console.WriteLine($"toast is ready({Thread.CurrentThread.ManagedThreadId})");

            Juice oj = PourOJ(3);
            Console.WriteLine($"oj is ready({Thread.CurrentThread.ManagedThreadId})");            

            var eggs = await eggsTask;
            Console.WriteLine($"eggs are ready({Thread.CurrentThread.ManagedThreadId})");

            var bacon = await baconTask;
            Console.WriteLine($"bacon is ready({Thread.CurrentThread.ManagedThreadId})");

            Console.WriteLine($"Breakfast is ready! Elapsed: {st.ElapsedMilliseconds } ms({Thread.CurrentThread.ManagedThreadId})");
        }

        private static Coffee PourCoffee(int v)
        {
            return new Coffee();
        }
        private static Task<Bacon> FryBaconAsync(int v)
        {
            Console.WriteLine($"FryBaconAsync({Thread.CurrentThread.ManagedThreadId})");
            Task.Delay(v).Wait();
            return Task.Run(() => new Bacon());
        }

        private static Task<Egg> FryEggsAsync(int v)
        {
            Console.WriteLine($"FryEggsAsync({Thread.CurrentThread.ManagedThreadId})");
            Task.Delay(v).Wait();
            return Task.Run(() => new Egg());
        }
        private async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private Task<Toast> ToastBreadAsync(int v)
        {
            Console.WriteLine($"ToastBreadAsync({Thread.CurrentThread.ManagedThreadId})");
            Task.Delay(v).Wait();
            return Task.Run<Toast>(() => new Toast());
        }

        private static Juice PourOJ(int v)
        {
            Task.Delay(v).Wait();
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            toast.ApplyJam();
        }

        private static void ApplyButter(Toast toast)
        {
            toast.ApplyButter();
        }            
    }
}
