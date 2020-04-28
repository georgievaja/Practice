using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class MissingInteger
    {
        public static int GetSmallestMissingInteger(int[] arr)
        {
            var positiveArr = new int[1000001];
            var smallest = 1;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    positiveArr[arr[i]]++;
                }
            }

            for (var i = 1; i < positiveArr.Length; i++)
            {
                if (positiveArr[i] == 0)
                    return i;
            }

            return smallest;
        }
    }
}
