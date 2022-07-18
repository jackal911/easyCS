using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LottoHighLow
{
    class Program
    {
        public class Solution
        {
            public int[] solution(int[] lottos, int[] win_nums)
            {
                int[] grade = new int[7] { 6, 6, 5, 4, 3, 2, 1 };
                int count = 0;
                int countZero = 0;
                foreach (int num in lottos)
                {
                    int a;
                    if (num == 0)
                        countZero++;
                    else if ((a=Array.Find(win_nums, s=>s==num))!=0)
                        count++;
                }
                return new int[2] { grade[count], grade[countZero + count] };
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] lottos = new int[6]{44, 1, 0, 0, 31, 25};
            int[] win_nums = new int[6]{31, 10, 45, 1, 6, 19};
            Array.ForEach(s.solution(lottos, win_nums), x => Console.Write(x + " "));
        }
    }
}
