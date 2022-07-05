using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step4 - 1차원 배열 https://www.acmicpc.net/step/6

namespace Step4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q10818 - 최소, 최대
            int N = int.Parse(Console.ReadLine());
            string[] nums = Console.ReadLine().Split();
            int min = 1000001;
            int max = -1000001;
            foreach (var num in nums)
            {
                int n = int.Parse(num);
                if (n < min)
                {
                    min = n;
                }
                if (n > max)
                {
                    max = n;
                }
            }
            Console.WriteLine("{0} {1}", min, max);
            
            // Q2562 - 최댓값
            int max = 0;
            int maxIndex = 0;
            for (int i = 1; i <= 9; i++)
            {
                int N = int.Parse(Console.ReadLine());
                if (N > max)
                {
                    max = N;
                    maxIndex = i;
                }
            }
            Console.Write("{0}\n{1}", max, maxIndex);
            
            // Q2577 - 숫자의 개수
            long mult = 1;
            for (var i = 0; i < 3; i++)
            {
                mult *= int.Parse(Console.ReadLine());
            }
            string num = mult.ToString();
            int[] zeroToNine = new int[10];
            foreach (var n in num)
            {
                zeroToNine[n - 48]++;
            }
            foreach (var j in zeroToNine)
            {
                Console.WriteLine(j);
            }
            
            // Q3052 - 나머지
            SortedSet<int> set = new SortedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                int remain = int.Parse(Console.ReadLine())%42;
                set.Add(remain);
            }
            Console.WriteLine(set.Count);
            
            // Q1546 - 평균
            int N = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
            int max = nums.Max();
            Console.WriteLine("{0:f}", nums.Average()/max*100);
            
            // Q8958 - OX퀴즈
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string ins = Console.ReadLine();
                int score = 0;
                int sum = 0;
                for (int j = 0; j < ins.Length; j++)
                {
                    if (ins[j] == 'O')
                    {
                        sum += ++score;
                    }
                    else
                    {
                        score = 0;
                    }
                }
                Console.WriteLine(sum);
            }
            */
            // Q4344 - 평균은 넘겠지
            int C = int.Parse(Console.ReadLine());
            for (int i = 0; i < C; i++)
            {
                double[] nums = Array.ConvertAll(Console.ReadLine().Split(), s => double.Parse(s));
                nums = nums.Where((e, idx) => idx != 0).ToArray();
                double avg = nums.Average();
                int goodBoy = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] > avg)
                    {
                        goodBoy++;
                    }
                }
                Console.WriteLine("{0:f3}%", (double)goodBoy / (double)nums.Length*100);
            }
        }
    }
}
