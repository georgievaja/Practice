using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class CountDiv
    {
        public static int CountDivisibleNum(int a, int b, int k)
        {
            var first= a % k == 0 ? a : a + (k - a % k);
            var last = b - b % k;
            var result = (last - first) / k + 1;

            return result;
        }
    }
}
