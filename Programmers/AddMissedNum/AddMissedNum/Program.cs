using System;
using System.Linq;

namespace AddMissedNum
{
    class Program
    {
        public class Solution
        {
            public int solution(int[] numbers)
            {
                return 45 - numbers.Sum();
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] numbers = { 1, 2, 3, 4, 6, 7, 8, 0 };
            Console.WriteLine(s.solution(numbers));            
        }
    }
}
