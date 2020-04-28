using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class PermCheck
    {
        public static int ArrayIsPermutation(int[] arr)
        {
            var sum = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                sum = (i + 1) ^ arr[i] ^ sum;

            }
            if (sum > 0)
                return 0;

            return 1;
        }
    }
}
