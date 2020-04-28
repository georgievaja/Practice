using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class MaxCounters
    {
        public static int[] ReturnCounters(int n, int[] a)
        {
            var arr = new int[n];
            var maximum = 0;
            int lastMaximum = 0;

            for (var i = 0; i < a.Length; i++)
            {
                var x = a[i];
                if (x >= 1 && x <= n)
                {
                    var increased = (arr[x-1]) + 1;
                    if (increased <= lastMaximum)
                    {
                        increased = lastMaximum + 1;
                    }

                    arr[x - 1] = increased;
                    
                    if (maximum < increased)
                    {
                        maximum = increased;
                    }
                }
                else if (x == n + 1)
                {
                    lastMaximum = maximum;
                }
            }

            arr.SetAllSmaller(lastMaximum);

            return arr;
        }

        public static void SetAllSmaller(this int[] arr, int val)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < val)
                {
                    arr[i] = val;
                }
            }
        }
    }
}
