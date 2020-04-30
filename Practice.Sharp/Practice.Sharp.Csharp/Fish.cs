using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class Fish
    {
        public static int GetNumberOfSurviving(int[] A, int[] B)
        {
            var survivingQueue = new Stack<Tuple<int,int>>();
            for (var i = 0; i < A.Length; i++)
            {
                if (B[i] == 1)
                {
                    survivingQueue.Push(Tuple.Create(A[i], 1));
                }
                else
                {
                    if (survivingQueue.Count == 0)
                    {
                        survivingQueue.Push(Tuple.Create(A[i], 0));
                    }
                    else
                    {
                        var lastOpposite = survivingQueue.Pop();
                        while (survivingQueue.Count > 0 && lastOpposite.Item2 == 1 && A[i] > lastOpposite.Item1)
                        {
                            lastOpposite = survivingQueue.Pop();
                        }

                        if (lastOpposite.Item2 == 1)
                        {
                            survivingQueue.Push(A[i] > lastOpposite.Item1 ? Tuple.Create(A[i], 0) : lastOpposite);
                        }
                        else
                        {
                            survivingQueue.Push(lastOpposite);
                            survivingQueue.Push(Tuple.Create(A[i], 0));
                        }
                    }
                }
            }

            return survivingQueue.Count;
        }
    }

    public class Dummy
    {

        public int Size { get; set; }
    }
}
