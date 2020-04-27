using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class TapeEquilibrium
    {
        public static int FindMinDiffIndex(int[] arr)
        {
            var sumLeft = arr.ArraySum(0,1);
            var sumRight = arr.ArraySum(1, arr.Length);
            var minDiff = Math.Abs(sumLeft - sumRight);

            for (var i = 1; i < arr.Length -1; i++)
            {
                    sumLeft += arr[i];
                    sumRight -= arr[i];


                    var diff = sumLeft - sumRight;
                    var absDiff = Math.Abs(diff);

                    if (absDiff < minDiff) minDiff = absDiff;
            }

            return minDiff;
        }

        public static int ArraySum(this int[] arr, int start, int end)
        {
            var sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }
}

