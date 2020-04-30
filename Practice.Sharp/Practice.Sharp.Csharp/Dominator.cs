using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Dominator
    {
        public static int FindDominator(int[] A)
        {
            var size = 0;
            var index = -1;
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
                return -1;
            }

            var candidate = stack.Pop();
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    index = i;
                    size++;
                }
            }

            if (size > A.Length / 2)
            {
                return index;
            }

            return -1;
        }
    }
}
