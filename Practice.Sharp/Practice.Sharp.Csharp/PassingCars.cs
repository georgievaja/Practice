using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class PassingCars
    {
        public static int CountCars(int[] arr)
        {
            var combinations = 0;
            var sums = new int[arr.Length + 1];

            for (var i = arr.Length -1; i >=0; i--)
            {
                if (arr[i] == 1)
                {
                    sums[i] = sums[i + 1] + 1;
                }
                else
                {
                    sums[i] = sums[i + 1];
                    if (combinations + sums[i] > 1000000000) return -1;
                    combinations += sums[i];
                }
            }

            return combinations;
        }
    }
}
