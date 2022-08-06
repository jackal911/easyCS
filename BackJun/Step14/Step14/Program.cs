using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step14
{
    // Step14 - 정수론 및 조합론 https://www.acmicpc.net/step/18
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q5086 - 배수와 약수
            string inp;
            while ((inp = Console.ReadLine()) != "0 0")
            {
                int[] twoNumber = Array.ConvertAll(inp.Split(), int.Parse);
                if (twoNumber[1] % twoNumber[0] == 0)
                {
                    Console.WriteLine("factor");
                }
                else if (twoNumber[0] % twoNumber[1] == 0)
                {
                    Console.WriteLine("multiple");
                }
                else
                {
                    Console.WriteLine("neither");
                }
            }
            
            // Q1037 - 약수
            Console.ReadLine();
            int[] factors = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine(factors.Max() * factors.Min());
            
            // Q2609 - 최대공약수와 최소공배수
            int[] twoNumbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int factor = 2;
            int GCD = 1;
            bool GoOn = true;
            while (GoOn)
            {
                if (twoNumbers[0] % factor == 0 && twoNumbers[1] % factor == 0)
                {
                    GCD *= factor;
                    twoNumbers[0] /= factor;
                    twoNumbers[1] /= factor;
                }
                else
                {
                    factor++;
                }

                if (factor > twoNumbers.Min())
                {
                    GoOn = false;
                }
            }
            Console.WriteLine(GCD);
            Console.WriteLine(GCD * twoNumbers[0] * twoNumbers[1]);
            
            // Q1934 - 최소공배수
            for (int T = int.Parse(Console.ReadLine()); T > 0; T--)
            {
                int[] twoNumber = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Array.Sort(twoNumber);
                if (twoNumber[1] % twoNumber[0]==0)
                {
                    Console.WriteLine(twoNumber[1]);
                }
                else
                {
                    int saveBigNumber = twoNumber[1];
                    while (twoNumber[1] % twoNumber[0] != 0)
                    {
                        twoNumber[1] += saveBigNumber;
                    }
                    Console.WriteLine(twoNumber[1]);
                }
            }
            */
            // Q2981 - 검문
            List<int> nums = new List<int>();
            for (int N = int.Parse(Console.ReadLine()); N > 0; N--)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }
            nums.Sort();
            int min = 1000000000;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                min = Math.Min(min, nums[i + 1] - nums[i]);
                if (min == 2)
                {
                    Console.WriteLine(2);
                    return;
                }
            }

            int realMin = Math.Min(min, nums.Min());
            

            List<int> result = new List<int>();            
            for (int i = 2; i <= realMin; i++)
            {
                if (result.Contains(i))
                {
                    break;
                }

                if (realMin % i == 0)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
