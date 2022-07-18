using System;
using System.Linq;

namespace AddPlusMinus
{
    class Program
    {
        public class Solution
        {
            public int solution(int[] absolutes, bool[] signs)
            {
                return absolutes.Select((value, index) => signs[index] == false ? -value : value).Sum();
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] absolutes = { 4, 7, 12 };
            bool[] signs = { true, false, true };
            Console.WriteLine(s.solution(absolutes, signs));
        }
    }
}
