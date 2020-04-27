using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class CyclicRotation
    {
        public static int[] RotateArray(int[] A, int K)
        {
            var N = A.Length;
            var rotatedArray = new int[A.Length];

            if (K < 0 || K > 100 || N == 0)
            {
                return rotatedArray;
            }

            if (N == 1)
            {
                return A;
            }

            for (var i = 0; i < N; i++)
            {
                rotatedArray[(i + K) % N] = A[i];
            }

            return rotatedArray;
        }
    }
}
