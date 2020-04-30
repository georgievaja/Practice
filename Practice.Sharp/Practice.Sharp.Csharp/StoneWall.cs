using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class StoneWall
    {
        public static int CountBlock(int[] H)
        {
            var count = 0;
            var blocks = new Stack<int>();

            for (int i = 0; i < H.Length; i++)
            {
                if (blocks.Count == 0)
                {
                    blocks.Push(H[i]);
                    count++;
                }
                else
                {
                    var prev = blocks.Pop();
                    while (blocks.Count > 0 && prev > H[i])
                    {
                        prev = blocks.Pop();
                    }

                    if (prev == H[i])
                    {
                        //there is already block covering it
                        blocks.Push(H[i]);
                    }
                    else
                    {
                        blocks.Push(prev);
                        blocks.Push(H[i]);
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
