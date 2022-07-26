using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressByN
{
    // N으로 표현 https://school.programmers.co.kr/learn/courses/30/lessons/42895
    class Program
    {
        public class Solution
        {
            public List<int> mins;
            public Solution(){
                this.mins = Enumerable.Repeat(0, 32001).ToList();
            }
            public int solution(int N, int number)
            {
                for (int i = 1; i <= number; i++)
                {
                    find(N, i);
                }
                return find(N, number);
            }
            public int find(int N, int number)
            {                
                if (number <= 0 || number>32000)
                {
                    return int.MaxValue;
                }
                else if (this.mins[number] != 0)
                {
                    return this.mins[number];
                }
                else if (number.ToString().All(s => (int)(s - 48) == N))
                {
                    this.mins[number] = number.ToString().Length;
                }
                else if (number.ToString().All(s => (int)(s - 48) == 1))
                {
                    this.mins[number] = number.ToString().Length + 1;
                }
                else
                {
                    int[] result = { find(N, number - 1), find(N, number + 1), find(N, number + 5), find(N, number - 5) };
                    this.mins[number] = result.Min();
                }
                return mins[number];
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int N = 5;
            int number = 12;
            Console.WriteLine(s.solution(N, number));
        }
    }
}
