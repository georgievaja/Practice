using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class MaxProductOfThree
    {
        public static int CountMaxProductOfThree(int[] A)
        {
            Array.Sort(A);

            var possiblyNegative = A[0] * A[1];
            var positive = A[A.Length - 2] * A[A.Length - 3];
            var allPositive = A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3];

            if (possiblyNegative > positive)
            {
                var res = possiblyNegative * A[A.Length - 1];
                if (res > allPositive)
                {
                    return res;
                }
            }

            return allPositive;
        }
    }
}
