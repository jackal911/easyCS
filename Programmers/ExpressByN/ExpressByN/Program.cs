using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ExpressByN
{
    // N으로 표현 https://school.programmers.co.kr/learn/courses/30/lessons/42895
    class Program
    {
        public class Solution
        {
            public List<int> counts;
            public Solution()
            {
                this.counts = Enumerable.Repeat(9, 32001).ToList();
            }
            public int solution(int N, int number)
            {
                // 선처리
                string ones = "1";
                string Ns = String.Format("{0}", N);
                for (int i = 1; i <= 5; i++)
                {
                    ones = String.Join("", Enumerable.Repeat("1", i));
                    int onesToNum = int.Parse(ones);
                    counts[onesToNum] = Math.Min(counts[onesToNum], ones.Length + 1);
                    if (i < 5 || N <= 2)
                    {
                        Ns = String.Join("", Enumerable.Repeat(String.Format("{0}", N), i));
                        int NsToNum = int.Parse(Ns);                        
                        counts[NsToNum] = Math.Min(counts[NsToNum], ones.Length);
                    }
                }
                int fivesMultiple = 1;
                while (counts[fivesMultiple] < 9)
                {
                    fivesMultiple *= 5;
                    counts[fivesMultiple] = Math.Min(counts[fivesMultiple], fivesMultiple / 5);
                }

                while (number > 0)
                {
                    find(N, number);
                }
                
                return counts[number] > 8 ? -1 : counts[number];
            }
            public int find(int N, int number)
            {
                return 1;
            }
//             public List<int> mins;
//             public Solution(){
//                 this.mins = Enumerable.Repeat(9, 32001).ToList();
//             }
//             public int solution(int N, int number)
//             {
//                 for (int i = 1; i <= number; i++)
//                 {
//                     find(N, i);
//                 }
//                 return find(N, number)>8 ? -1 : find(N, number);
//             }
//             public int find(int N, int number)
//             {                
//                 if (number <= 0 || number>32000)
//                 {
//                     return 9;
//                 }                
//                 else if (number.ToString().All(s => (int)(s - 48) == N))
//                 {
//                     this.mins[number] = Math.Min(number.ToString().Length, mins[number]);
//                 }
//                 else if (number.ToString().All(s => (int)(s - 48) == 1))
//                 {
//                     this.mins[number] = Math.Min(number.ToString().Length + 1, mins[number]);
//                     
//                 }
//                 else if (number % N == 0)
//                 {
//                     this.mins[number] = Math.Min(number / N, this.mins[number]);
//                 }
//                 else if (this.mins[number] < 9)
//                 {
//                     return this.mins[number];
//                 }
//                 else
//                 {
//                     int[] result = { find(N, number - 1) + 1, find(N, number - N) + 1, number%N==0 ? find(N, number/N) + 1 : 9 };
//                     this.mins[number] = result.Min();
//                 }
// 
//                 for (int i = 1; i < N && i <= number; i++)
//                 {
//                     this.mins[number + i] = Math.Min(this.mins[number] + i, this.mins[number + i]);
//                     this.mins[number - i] = Math.Min(this.mins[number] + i, this.mins[number - i]);
//                 }
//                 if (number >= N)
//                 {
//                     this.mins[number - N] = Math.Min(this.mins[number] + 1, this.mins[number - N]);
//                 }
//                 this.mins[number + N] = Math.Min(this.mins[number] + 1, this.mins[number + N]);
// 
//                 if (this.mins[number] > 9)
//                 {
//                     this.mins[number] = 9;
//                     return 9;
//                 }
// 
//                 Console.WriteLine("{0} : {1} 으로 수정", number, mins[number]);
//                 //Thread.Sleep(500);
//                 return this.mins[number];
//             }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int N = 5;
            int number = 31168;
            Console.WriteLine(s.solution(N, number));
        }
    }
}
