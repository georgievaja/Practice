using System;
namespace Practice.Sharp.Csharp
{
    public static class BinaryGap
    {
        public static int GetBinaryGap(string n)
        {
            if (int.TryParse(n, out int number) && number > 0 && number < 2147483647)
            {
                var b = Convert.ToString(number, 2);

                int longest = 0;
                int curCount = 0;

                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] == '0')
                    {
                        curCount++;
                    }else
                    {
                        curCount = 0;
                    }

                    if (curCount > longest) longest = curCount;
                }

                return longest;
            }

            return 0;
        }
    }
}
