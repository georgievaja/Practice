using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class OddOccurrence
    {
        public static int GetOccurence(int[] arr)
        {
            var diff = 0;
            if (!arr.IsInRange(1, 1000000)) return diff;

            for (var i = 0; i < arr.Length; i++)
            {
                if (!arr[i].IsInRange(1, 1000000000)) return 0;

                diff ^= arr[i];
            }

            return diff;
        }
    }
}
