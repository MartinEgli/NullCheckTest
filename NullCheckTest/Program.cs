using System;
using System.Diagnostics;

namespace NullCheckTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var loops = 10000000;
            TimeSpan time;
            sw.Reset();
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                Test0(i);
            }
            time = sw.Elapsed;
            Console.WriteLine("Time " + time);
            
            sw.Reset();
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                Test1(i);
            }
            time = sw.Elapsed;
            Console.WriteLine("Time " + time);

            sw.Reset();
            sw.Start();
            for (int i = 0; i < loops; i++)
            {
                Test2(i);
            }
            time = sw.Elapsed;
            Console.WriteLine("Time " + time);
        }

        private static void Test0(object i)
        {
        }

        private static void Test1(object i)
        {
            if (i == null) throw new ArgumentNullException(nameof(i));
        }

        private static void Test2(object i)
        {
            i.ThrowIfNull(nameof(i));
        }
    }

    public static class Extensions
    {
        public static void ThrowIfNull<TObject>(this TObject argument, string parameterName) where TObject : class
        {
            if (argument is null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

    }
}
