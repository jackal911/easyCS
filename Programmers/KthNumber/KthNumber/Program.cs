using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KthNumber
{
    class Program
    {
        public class Solution
        {
            public int[] solution(int[] array, int[,] commands)
            {
                List<int> answer = new List<int>();
                for(int i=0;i<commands.Length/3;i++)
                {
                    int[] sliced = array.Where((value, index)=>(index>=commands[i,0]-1 && index<commands[i,1])).ToArray();
                    Array.Sort(sliced);
                    answer.Add(sliced[commands[i, 2] - 1]);
                }
                return answer.ToArray();
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] a = { 1, 5, 2, 6, 3, 7, 4 };
            int[,] b = {{2, 5, 3}, {4, 4, 1}, {1, 7, 3}};
            Array.ForEach(s.solution(a, b), x=>Console.WriteLine(x));
        }
    }
}
