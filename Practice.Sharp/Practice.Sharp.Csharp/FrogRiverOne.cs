using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class FrogRiverOne
    {
        public static int GetTimeToJump(int[] arr, int finalPosition)
        {
            var positions = new int[finalPosition + 1];
            var leftToFill = finalPosition;

            var index = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (leftToFill == 0) return index;
                index = i;
                
                if (positions.Length <= arr[i] || positions[arr[i]] > 0) continue;

                positions[arr[i]] = arr[i];
                leftToFill--;
            }

            return (leftToFill > 0) ? -1 : index;
        }
    }
}
