using System;
using System.Linq;

namespace reverseTernary
{
    // 3진법 뒤집기 https://school.programmers.co.kr/learn/courses/30/lessons/68935
    class Program
    {
        public class Solution
        {
            public int solution(int n)
            {
                string ternary = notation(n, 3);
                int answer = ternary.Select((v, i) => (int)(v - 48) * (int)Math.Pow(3, i)).Sum();
                return answer;
            }
            public string notation(int n, int not)
            {
                string result = "";
                while (n > 0)
                {
                    result = n % 3 + result;
                    n /= 3;
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int n = 125;
            Console.WriteLine(s.solution(n));
        }
    }
}
