using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalDotProduct
{
    // 내적 https://school.programmers.co.kr/learn/courses/30/lessons/70128
    class Program
    {
        public class Solution
        {
            public int solution(int[] a, int[] b)
            {
                return a.Select((v, i) => v * b[i]).Sum();
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] a = { 1, 2, 3, 4 };
            int[] b = { -3, -1, 0, 2 };
            Console.WriteLine(s.solution(a, b));
        }
    }
}
