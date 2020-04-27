using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class PerfMissingElem
    {
        public static int FoundMissingPermutation(int[] arr)
        {
            var length = arr.Length;
            var expected = length + 1; // missing from for loop
            var result = 0;

            for (var i = 0; i <= length; i++)
            {
                if (i != length)
                {
                    result += arr[i];
                }
                expected += i;
            }

            return expected - result;
        }
    }
}
