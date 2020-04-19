using System;

namespace Practice.Sharp.Csharp
{
    /// <summary>
    /// Time complexity c * n2
    /// </summary>
    public static class InsertionSort
    {
        public static int[] SortUsingInsertion(this int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                while(i > 0 && array[i] < array[i -1])
                {
                    var bigger = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = bigger;
                    i -= i;
                }
            }

            return array;
        }
    }
}
