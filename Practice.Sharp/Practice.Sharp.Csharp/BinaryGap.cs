using System;
namespace Practice.Sharp.Csharp
{
    public static class BinaryGap
    {
        public static int GetBinaryGap(int num)
        {
            var current = 0;
            var max = 0;
            var counting = false;

            for(uint i= 0; i < sizeof(int) * 8; i++)
            {
                var currPowTwo = (int)Math.Pow(2.0, i);

                if(currPowTwo == (num & currPowTwo))
                {
                    max = current > max ? current : max;
                    current = 0;
                    counting = true;
                }
                else
                {
                    if(counting) current++;
                }
            }

            return max;
        }
    }
}
