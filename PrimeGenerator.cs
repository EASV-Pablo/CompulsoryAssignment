using MeasureTime;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CompulsoryAssigment
{
    class PrimeGenerator
    {
        private static readonly object locker = new Object();

        public static void PrintList(List<long> list)
        {
            Console.WriteLine("Aqui");
            for (long i = 0L; i < list.Count; i++)
            {
                System.Diagnostics.Debug.Write(list[(int)i] + ", ");
            }
        }

        public static List<long> GetPrimesSequential(long first, long last)
        {
            List<long> primeList = new List<long>();
            for (long i = first; i <= last; i++)
            {
                if (IsPrime(i))
                {
                    primeList.Add(i);
                }
            }
            return primeList;
        }

        public static List<long> GetPrimesParallel(long first, long last)
        {
            List<long> primeList = new List<long>();
            Parallel.ForEach(
                Partitioner.Create(first, last + 1),
                (range) =>
                {
                    List<long> partialList = new List<long>();
                    for (long i = range.Item1; i < range.Item2; i++)
                    {
                        if (IsPrime(i))
                        {
                            partialList.Add(i);
                        }
                    }

                    lock (locker)
                    {
                        for (int j = 0; j < partialList.Count; j++)
                        {
                            primeList.Add(partialList[j]);
                        }
                    }
                });
            primeList.Sort();
            return primeList;
        }

        public static List<long> GetPrimesParallel(long first, long last, CancellationToken token)
        {
            List<long> primeList = new List<long>();
            Parallel.ForEach(
                Partitioner.Create(first, last+1),
                (range) =>
                {
                    List<long> partialList = new List<long>();
                    for (long i = range.Item1; i < range.Item2; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        else 
                        {
                            if (IsPrime(i))
                            {
                                partialList.Add(i);
                            }
                        }                        
                    }

                    lock (locker)
                    {
                        for (int j = 0; j < partialList.Count; j++)
                        {
                            primeList.Add(partialList[j]);
                        }
                    }
                });
            primeList.Sort();
            return primeList;
        }

        private static bool IsPrime(long n)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            long sqrtN = (long)Math.Sqrt(n) + 1;
            for (long i = 6L; i <= sqrtN; i += 6)
            {
                if (n % (i - 1) == 0 || n % (i + 1) == 0)
                {
                    return false;
                }
            }
            return true;
        }


        //Test zone
        public static long firstN = 1L;
        public static long lastN = 10_000_000L;
        public static List<long> listSequentialTest;
        public static List<long> listParallelTest;

        public static void Run()
        {
            Console.WriteLine("####################################");
            Console.WriteLine("     ###  a) 1 - 1.000.000  ###");
            Console.WriteLine("####################################");
            firstN = 1L;
            lastN = 1_000_000L;
            MeasureTimeClass.MeasureTime(CallGetPrimesSequential, "Sequential method: ");
            MeasureTimeClass.MeasureTime(CallGetPrimesParallel, "Parallel method: ");

            Console.WriteLine("#####################################");
            Console.WriteLine("     ###  b) 1 - 10.000.000  ###");
            Console.WriteLine("#####################################");
            firstN = 1L;
            lastN = 10_000_000L;
            MeasureTimeClass.MeasureTime(CallGetPrimesSequential, "Sequential method: ");
            MeasureTimeClass.MeasureTime(CallGetPrimesParallel, "Parallel method: ");

            Console.WriteLine("###########################################");
            Console.WriteLine("     ###  c) 1.000.000 - 2.000.000  ###");
            Console.WriteLine("###########################################");
            firstN = 1_000_000L;
            lastN = 2_000_000L;
            MeasureTimeClass.MeasureTime(CallGetPrimesSequential, "Sequential method: ");
            MeasureTimeClass.MeasureTime(CallGetPrimesParallel, "Parallel method: ");

            Console.WriteLine("#############################################");
            Console.WriteLine("     ###  d) 10.000.000 - 20.000.000  ###");
            Console.WriteLine("#############################################");
            firstN = 10_000_000L;
            lastN = 20_000_000L;
            MeasureTimeClass.MeasureTime(CallGetPrimesSequential, "Sequential method: ");
            MeasureTimeClass.MeasureTime(CallGetPrimesParallel, "Parallel method: ");

            Console.WriteLine("All results can be verified using the method 'printList(list)'");
        }

        public static void CallGetPrimesSequential()
        {
            listSequentialTest = GetPrimesSequential(firstN, lastN);
        }

        public static void CallGetPrimesParallel()
        {
            listParallelTest = GetPrimesParallel(firstN, lastN);
        }
    }
}
