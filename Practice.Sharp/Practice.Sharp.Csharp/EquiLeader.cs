using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class EquiLeader
    {
        public static int GetEquiLeadersCount(int[] A)
        {
            var stack = new Stack<int>();
            for (var i = 0; i < A.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(A[i]);
                }
                else
                {
                    var val = stack.Pop();
                    if (val == A[i])
                    {
                        stack.Push(val);
                        stack.Push(A[i]);
                    }
                }
            }

            if (stack.Count == 0)
            {
                return 0;
            }

            var candidate = stack.Pop();
            var sums = new int[A.Length+1];
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    sums[i + 1] = sums[i] + 1;
                }
                else
                {
                    sums[i + 1] = sums[i];
                }
            }

            var indexes = 0;
            if (sums[A.Length] > A.Length / 2)
            {
                for (var i = 1; i < sums.Length; i++)
                {
                    var leftSideSum = sums[i];
                    var rightSideSum = sums[sums.Length - 1] - leftSideSum;
                    var rightSideCount = sums.Length - 1 - i;
                    if (leftSideSum > i / 2 && rightSideSum > rightSideCount / 2)
                    {
                        indexes++;
                    }
                }

                return indexes;
            }

            return 0;
        }
    }
}
