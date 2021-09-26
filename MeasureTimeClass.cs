using System;
using System.Diagnostics;

namespace MeasureTime
{
    public class MeasureTimeClass
    {
        public static void MeasureTime(Action ac)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            Console.WriteLine("     Time elapsed: {0:F5} sec. \n", sw.Elapsed.TotalSeconds);
        }
        public static void MeasureTime(Action ac, string message)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            Console.WriteLine(message);
            Console.WriteLine("     Time elapsed: {0:F5} sec. \n", sw.Elapsed.TotalSeconds);
        }
    }
}
