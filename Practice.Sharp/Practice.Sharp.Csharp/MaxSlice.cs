using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class MaxSlice
    {
        public static int CountMaxSlice(int[] A)
        {
            var (maxEnding, maxSlice) = (0, 0);

            for (var i = 0; i < A.Length; i++)
            {
                maxEnding = Math.Max(0, maxEnding + A[i]);
                maxSlice = Math.Max(maxSlice, maxEnding);
            }

            return maxSlice;
        }

        public static int CountMaxProfit(int[] A)
        {
            if (A.Length < 2) return 0;

            var sliceTable = new int[A.Length];
            sliceTable[0] = 0;
            for (var i = 1; i < A.Length; i++)
            {
                sliceTable[i] = A[i] - A[i - 1];
            }

            var (maxEnding, maxSlice) = (0, 0);

            for (var i = 0; i < sliceTable.Length; i++)
            {
                maxEnding = Math.Max(0, maxEnding + sliceTable[i]);
                maxSlice = Math.Max(maxSlice, maxEnding);
            }

            return maxSlice;
        }

        public static int CountMaxSliceSum(int[] A)
        {
            var N = A.Length;
            var K1 = new long[N];

            var max = Int64.MinValue;
            for (var i = 0; i < N; i++)
            {
                if (i != 0)
                {
                    K1[i] = (Math.Max(K1[i - 1], 0) + A[i]);
                }
                else
                {
                    K1[0] = A[i];
                }

                if (K1[i] > max)
                {
                    max = K1[i];
                }
            }

            return (max > Int32.MaxValue || max < Int32.MinValue) ? -1 : (int)max;
        }

        public static int CountDoubleMaxSlice(int[] A)
        {
            var N = A.Length;
            var K1 = new int[N];
            var K2 = new int[N];

            for (var i = 1; i < N - 1; i++)
            {
                K1[i] = Math.Max(K1[i - 1] + A[i], 0);
            }
            for (var i = N - 2; i > 0; i--)
            {
                K2[i] = Math.Max(K2[i + 1] + A[i], 0);
            }

            var max = 0;

            for (var i = 1; i < N - 1; i++)
            {
                max = Math.Max(max, K1[i - 1] + K2[i + 1]);
            }

            return max;
        }
    }
}
