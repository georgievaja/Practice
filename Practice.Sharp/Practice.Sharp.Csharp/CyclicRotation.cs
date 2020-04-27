using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class CyclicRotation
    {
        public static void RotateArray(int[] arr, int steps)
        {
            var rotationPoint = steps % arr.Length;
            if (rotationPoint != 0)
            {
                var split = rotationPoint - 1;
                var temp = new int[split];

                Array.Copy(arr, temp, split);
                Array.Copy(arr, split, arr, 0, arr.Length - split);
                Array.Copy(temp, 0, arr, arr.Length - split, split);
            }
        }
    }
}
