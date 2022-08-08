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
            
            // Q2981 - 검문
            List<int> nums = new List<int>();
            for (int N = int.Parse(Console.ReadLine()); N > 0; N--)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }
            nums.Sort();
            nums.Reverse();
            int gcd = nums[0] - nums[1];
            if(nums.Count > 2)
            {
                gcd = getGcd(gcd, nums[1] - nums[2]);
                for (int i = 2; i < nums.Count - 1; i++)
                {
                    gcd = getGcd(gcd, nums[i] - nums[i + 1]);
                }                
            }

            List<int> result = getFactors(gcd).Where(s => s != 1).ToList();
            result.Sort();
            result.ForEach(s => Console.Write(s + " "));

               // 시간초과
//             for (int i = 2; i <= nums[1]; i++)
//             {
//                 int remainder = nums[0] % i;
//                 bool isok = nums.All(s => s % i == remainder);
//                 if (isok)
//                 {
//                     result.Add(i);
//                 }
//             }
//             Console.WriteLine(String.Join(" ", result));
            
            // Q3036 - 링
            Console.ReadLine();
            int[] rings = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 1; i < rings.Length; i++)
            {
                int g = getGcd(rings[0], rings[i]);
                Console.WriteLine("{0}/{1}", rings[0] / g, rings[i] / g);
            }
            */
            // Q11050 - 이항 계수 1
            int[] twoNum = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            if (twoNum[1] == 0 || twoNum[1] == twoNum[0])
            {
                Console.WriteLine(1);
                return;
            }
            int[] lst = { 1, 1 };
            for (int i = 1; i < twoNum[0]; i++)
            {
                List<int> newList = new List<int>();
                newList.Add(1);
                for (int j = 0; j < lst.Length - 1; j++)
                {
                    newList.Add(lst[j] + lst[j + 1]);
                }
                newList.Add(1);
                lst = new int[newList.Count];
                newList.CopyTo(lst);
            }
            Console.WriteLine(lst[twoNum[1]]);
        }
        public static int getGcd(int a, int b)
        {
            int r = a % b;
            if (r == 0)
            {
                return b;
            }
            return getGcd(b, r);            
        }

        public static IEnumerable<int> getFactors(int a)
        {
            int max = (int)Math.Sqrt(a);
            for (int i = 1; i <= max; i++)
            {
                if (a % i == 0)
                {
                    yield return i;
                    if (i * i != a)
                    {
                        yield return a / i;
                    }
                }
            }
        }
    }
}
