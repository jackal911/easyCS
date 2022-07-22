using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockExam
{
    public class Solution
    {
        public int[] solution(int[] answers)
        {
            List<int> answer = new List<int>();
            List<int> counts = new List<int>();
            int[][] SuPoJas = { new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 1, 2, 3, 2, 4, 2, 5 }, new int[] { 3, 1, 2, 4, 5 } };
            int[] divider = { 5, 8, 5 };
            for (int i = 0; i < 3; i++)
            {
                counts.Add(answer.Where((v, idx) => (v == SuPoJas[i][idx / divider[i]])).Count());
            }
            return counts.Where((v, i) => v == counts.Max()).ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] a = { 1, 2, 3, 4, 5 };
            Array.ForEach(s.solution(a), x => Console.Write(x + " "));
        }
    }
}
