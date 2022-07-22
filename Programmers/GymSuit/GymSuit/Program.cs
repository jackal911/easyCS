using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymSuit
{
    public class Solution
    {
        public int solution(int n, int[] lost, int[] reserve)
        {                        
            Array.Sort(lost);
            Array.Sort(reserve);
            int[] temp = lost.Except(reserve).ToArray();
            reserve = reserve.Except(lost).ToArray();
            lost = temp;
            int answer = n - lost.Length;
            foreach (int num in lost)
            {
                if (Array.Exists(reserve, s => s == num - 1))
                {
                    answer++;
                    reserve = reserve.Select(s => s == num - 1 ? -s : s).ToArray();
                }
                else if (Array.Exists(reserve, s => s == num + 1))
                {
                    answer++;
                    reserve = reserve.Select(s => s == num + 1 ? -s : s).ToArray();
                }
            }
            return answer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int n = 5;
            int[] lost = { 1, 2, 3, 4 };
            int[] reserve = { 1, 2, 3, 5 };
            Console.WriteLine(s.solution(n, lost, reserve));
        }
    }
}
