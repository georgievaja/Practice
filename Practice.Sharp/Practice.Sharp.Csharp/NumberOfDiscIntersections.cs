using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class NumberOfDiscIntersections
    {
        public static int Count(int[] A)
        {
            var lowers = new long[A.Length];
            var uppers = new long[A.Length];

            for (var i = 0; i < A.Length; i++)
            {
                lowers[i] = (long)i - (long)A[i];
                uppers[i] = (long)i + (long)A[i];
            }

            Array.Sort(lowers);
            Array.Sort(uppers);

            var lower = 0;
            var intersect = 0;

            for (var i = 0; i < A.Length; i++)
            {
                while (lower < A.Length && uppers[i] >= lowers[lower])
                {
                    lower += 1;
                }
                intersect += lower - i - 1;
            }

            if (intersect > 10000000) return -1;

            return intersect;
        }
    }
}
