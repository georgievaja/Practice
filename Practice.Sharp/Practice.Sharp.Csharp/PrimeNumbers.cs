using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class PrimeNumbers
    {
        public static int CountPeaksSlices(int[] A)
        {
            var peaks = new bool[A.Length];
            var next = new int[A.Length];
            var hasPeak = false;

            peaks[0] = false;
            next[A.Length - 1] = -1;

            for (var i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    hasPeak = true;
                    peaks[i] = true;
                }
                else
                {
                    peaks[i] = false;
                }
            }


            if (!hasPeak) return 0;
            
            for (var i = A.Length - 2; i > -1; i--)
            {
                if (peaks[i])
                {
                    next[i] = i;
                }
                else
                {
                    next[i] = next[i + 1];
                }
            }

            var index = 0;

            var dividers = GetDividers(next.Length);

            while (dividers[index] != 0)
            {
                var size = dividers[index];
                var nextI = 0;

                while (nextI < next.Length - size 
                       && next[nextI + size] != -1
                       && (next[nextI] != next[nextI + size] 
                           || (next[nextI + size + size - 1] != -1 
                               && next[nextI] != next[nextI + size + size - 1])))
                {
                    nextI += size;
                }

                if (nextI == next.Length - size)
                {
                    return next.Length / size;
                }

                index++;

            }

            return 1;
        }

        public static int[] GetDividers(int n)
        {
            var i = 1;
            var index = 0;
            var divisors = new int[n];

            while (i <= n)
            {
                if (n % i == 0)
                {
                    divisors[index] = i;
                    index++;
                }

                i++;
            }

            return divisors;
        }
        public static int CountFlags(int[] A)
        {
            var peaks = new bool[A.Length];
            var next = new int[A.Length];

            peaks[0] = false;
            next[A.Length - 1] = -1;

            for (var i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peaks[i] = true;
                }
                else
                {
                    peaks[i] = false;
                }
            }

            for (var i = A.Length - 2; i > -1; i--)
            {
                if (peaks[i])
                {
                    next[i] = i;
                }
                else
                {
                    next[i] = next[i + 1];
                }
            }

            var ind = 1;
            var result = 0;

            while ((ind - 1) * ind <= A.Length)
            {
                var pos = 0;
                var num = 0;

                while (pos < A.Length && num < ind)
                {
                    pos = next[pos];

                    if (pos == -1)
                    {
                        break;
                    }

                    num++;
                    pos += ind;
                }

                result = Math.Max(result, num);
                ind++;
            }

            return result;
        }
        public static int CountNumberOfDivisors(int n)
        {
            var i = 1L;
            var result = 0;

            while (i * i < n)
            {
                if (n % i == 0)
                {
                    result += 2;
                }

                i++;
            }

            if (i * i == n)
            {
                result++;
            }

            return result;
        }

        public static bool IsPrimeNumber(int n)
        {
            var i = 2;
            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
