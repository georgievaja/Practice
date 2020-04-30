using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class PrefixSums
    {
        public static int[] CountPrefixSums(int[] a)
        {
            var n = a.Length;
            var p = new int[n +1];

            for (var k = 1; k < n +1; k++)
            {
                p[k] = p[k-1] + a[k-1];
            }

            return p;
        }

        public static int CountTotal(int[] arr, int left, int right)
        {
            return arr[right + 1] - arr[left];
        }

        public static int MushroomPicker(int[] arr, int spot, int moves)
        {
            var n = arr.Length;
            var result = 0;
            var pref = CountPrefixSums(arr);

            for (var p = 0; p < (Math.Min(moves, spot) + 1); p++)
            {
                var leftPos = spot - p;
                var rightPos = Math.Min(n - 1, Math.Max(spot, (spot + moves - 2 * p)));
                result = Math.Max(result, CountTotal(pref, leftPos, rightPos));
            }

            for (var p = 0; p < Math.Min(moves +1, n - spot); p++)
            {
                var rightPos = spot + p;
                var leftPos = Math.Max(0, Math.Min(spot, (spot -( moves - 2 * p))));
                result = Math.Max(result, CountTotal(pref, leftPos, rightPos));
            }

            return result;
        }
    }
}
