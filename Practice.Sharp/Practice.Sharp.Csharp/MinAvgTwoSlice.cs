using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class MinAvgTwoSlice
    {
        /// <summary>
        /// only avg 2 and 3 matters
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int FindStartingPoint(int[] a)
        {
            var minAvr = float.MaxValue;
            var index = a.Length - 1;
            for (var i = a.Length - 1; i >= 0; i--)
            {
                if (i <= a.Length - 2)
                {
                    var sum = a[i] + a[i + 1];
                    var avr = (float)sum / 2;
                    if (minAvr >= avr)
                    {
                        minAvr = avr;
                        index = i;
                    }
                }

                if (i <= a.Length - 3)
                {
                    var sum = a[i] + a[i + 1] + a[i + 2];
                    var avr = (float)sum / 3;
                    if (minAvr >= avr)
                    {
                        minAvr = avr;
                        index = i;
                    }
                }
            }

            return index;
        }
    }
}
