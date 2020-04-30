using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Sharp.Csharp
{
    public static class GenomicRangeQuery
    {
        public static int[] GetMinimalNucleotideFactors(int[] P, int[] Q, string S)
        {
            var nucleotides = new int[3][];
            nucleotides[0] = new int[S.Length + 1]; // A
            nucleotides[1] = new int[S.Length + 1]; // C
            nucleotides[2] = new int[S.Length + 1]; // G

            var result = new int[P.Length];
            FillNucleotides(S, nucleotides);

            for (var i = 0; i < P.Length; i++)
            {
                var start = P[i];
                var end = Q[i];

                result[i] = GetMin(nucleotides, start, end);
            }

            return result;
        }

        private static void FillNucleotides(string s, int[][] nucleotides)
        {
            for (var i = 1; i < s.Length + 1; i++)
            {
                switch (s[i- 1])
                {
                    case 'A':
                        nucleotides[0][i] = nucleotides[0][i - 1] + 1;
                        nucleotides[2][i] = nucleotides[2][i - 1];
                        nucleotides[1][i] = nucleotides[1][i - 1];
                        break;
                    case 'C':
                        nucleotides[0][i] = nucleotides[0][i - 1];
                        nucleotides[2][i] = nucleotides[2][i - 1];
                        nucleotides[1][i] = nucleotides[1][i - 1]  + 1;
                        break;
                    case 'G':
                        nucleotides[0][i] = nucleotides[0][i - 1];
                        nucleotides[2][i] = nucleotides[2][i - 1] + 1;
                        nucleotides[1][i] = nucleotides[1][i - 1];
                        break;
                    case 'T':
                        nucleotides[0][i] = nucleotides[0][i - 1];
                        nucleotides[2][i] = nucleotides[2][i - 1];
                        nucleotides[1][i] = nucleotides[1][i - 1];
                        break;
                }
            }
        }

        private static int GetMin(int[][] nucleotides, int start, int end)
        {
            if (nucleotides[0][end+1] - nucleotides[0][start] > 0) return 1;
            if (nucleotides[1][end + 1] - nucleotides[1][start] > 0) return 2;
            
            return nucleotides[2][end + 1] - nucleotides[2][start] > 0 ? 3 : 4;
        }
    }
}
