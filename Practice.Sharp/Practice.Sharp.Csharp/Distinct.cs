using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Distinct
    {
        public static int CountDistinctInt(int[] A)
        {
            var result = 0;
            Array.Sort(A);
            for (var i = 0; i < A.Length; i++)
            {
                if (i == 0)
                {
                    result++;
                }
                else
                {
                    if (A[i] != A[i - 1])
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
