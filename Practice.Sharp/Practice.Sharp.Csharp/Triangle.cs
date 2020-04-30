using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Triangle
    {
        public static int TriangleExists(int[] A)
        {
            Array.Sort(A);

            for (var i = 0; i < A.Length - 2; i++)
            {
                if ((long)A[i] + (long)A[i + 1] > (long)A[i + 2])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
