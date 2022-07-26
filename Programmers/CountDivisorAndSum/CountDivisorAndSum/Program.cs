using System;
using System.Linq;

namespace CountDivisorAndSum
{
    // 약수의 개수와 덧셈 https://school.programmers.co.kr/learn/courses/30/lessons/77884
    class Program
    {
        public class Solution
        {
            public int solution(int left, int right)
            {
                int sum = Enumerable.Range(left, right - left + 1).Sum();
                for (int i = (int)Math.Ceiling(Math.Sqrt(left)); i <= (int)Math.Truncate(Math.Sqrt(right)); i++)
                {
                    sum -= (int)(2 * (Math.Pow(i, 2)));
                }
                return sum;
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int a = 24;
            int b = 27;
            Console.WriteLine(s.solution(a, b));
        }
    }
}
