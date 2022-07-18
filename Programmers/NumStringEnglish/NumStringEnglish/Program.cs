using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumStringEnglish
{
    class Program
    {
        public class Solution
        {
            public int solution(string s)
            {
                string[] strByNum = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                for(int i=0;i<10;i++)
                {
                    s = s.Replace(strByNum[i], i.ToString());
                }
                int answer = Int32.Parse(s);
                return answer;
            }
        }
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string s = "one4seveneight";
            Console.WriteLine(sol.solution(s));
        }
    }
}
