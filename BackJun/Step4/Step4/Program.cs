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
            */
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
        }
    }
}
