using MeasureTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryAssigment
{
    class IsPrimeTest
    {
        static int i = 2;
        static readonly int n = 100_003;
        //static int n = 9887;

        public void Run()
        {
            Console.WriteLine("Recursivity mode:");
            MeasureTimeClass.MeasureTime(CallPrimeRecursivity);
            Console.WriteLine("\n\nRoot mode:");
            MeasureTimeClass.MeasureTime(CallPrimeRoot);
            Console.WriteLine("\n\nOptimal linear mode:");
            MeasureTimeClass.MeasureTime(CallPrimeLinearOptimal);
            Console.WriteLine("\n\nHalf-linear mode:");
            MeasureTimeClass.MeasureTime(CallPrimeLinear2);
            Console.WriteLine("\n\nLineal:");
            MeasureTimeClass.MeasureTime(CallPrimeLinear);
        }

        public static void CallPrimeRecursivity()
        {
            Console.WriteLine(IsPrimeRecursivity(n));
        }

        public static void CallPrimeRoot()
        {
            Console.WriteLine(IsPrimeRoot(n));
        }

        public static void CallPrimeLinearOptimal()
        {
            Console.WriteLine(IsPrimeLinearOptimal(n));
        }

        public static void CallPrimeLinear2()
        {
            Console.WriteLine(IsPrimeLinear2(n));
        }

        public static void CallPrimeLinear()
        {
            Console.WriteLine(IsPrimeLinear(n));
        }

        //This method crashes with highs numbers
        static bool IsPrimeRecursivity(int n)
        {
            // corner cases
            if (n == 0 || n == 1)
            {
                return false;
            }

            // Checking Prime
            if (n == i)
                return true;

            // base cases
            if (n % i == 0)
            {
                return false;
            }
            i++;
            return IsPrimeRecursivity(n);
        }

        static bool IsPrimeRoot(int n)
        {
            int z = 0;
            // Corner case
            if (n <= 1)
                return false;

            int squareRoot = (int)Math.Sqrt(n);
            // Check from 2 to n-1
            for (int i = 2; i <= squareRoot; i++)
            {
                z++;
                if (n % i == 0)
                {
                    Console.WriteLine(z + " iterations");
                    return false;
                }
            }

            Console.WriteLine(z + " iterations");
            return true;
        }

        static bool IsPrimeLinearOptimal(long n)
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

        static bool IsPrimeLinear2(int n)
        {
            int z = 0;
            // Corner case
            if (n <= 1)
                return false;

            // Check from 2 to n/2
            for (int i = 2; i <= n / 2; i++)
            {
                z++;
                if (n % i == 0)
                {
                    Console.WriteLine(z + " iterations");
                    return false;
                }
            }

            Console.WriteLine(z + " iterations");
            return true;
        }

        static bool IsPrimeLinear(int n)
        {
            int z = 0;
            // Corner case
            if (n <= 1)
                return false;

            // Check from 2 to n-1
            for (int i = 2; i < n; i++)
            {
                z++;
                if (n % i == 0)
                {
                    Console.WriteLine(z + " iterations");
                    return false;
                }
            }

            Console.WriteLine(z + " iterations");
            return true;
        }

    }
}
