using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step8 - 기본 수학 2

namespace Step8
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q1978 - 소수 찾기
            int N = int.Parse(Console.ReadLine());
            List<int> nums = Console.ReadLine().Split().ToList().ConvertAll(s => int.Parse(s));
            nums.RemoveAll(s=>s==1);
            int max = nums.Max();
            for (int i = 2; i <= Math.Sqrt(max); i++)
            {
                int j = 2;
                while (i * j <= max)
                {
                    if (nums.Contains(i * j))
                    {
                        nums.Remove(i * j);
                    }
                    j++;
                }
            }
            Console.WriteLine(nums.Count);
            
            // Q2581 - 소수
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            List<int> nums = Enumerable.Range(M, N-M+1).ToList();
            nums.Remove(1);
            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                int j = 2;
                while (i * j <= N)
                {
                    if (nums.Contains(i * j))
                    {
                        nums.Remove(i * j);
                    }
                    j++;
                }
            }
            if (nums.Count == 0)
                Console.WriteLine(-1);
            else
            {
                Console.WriteLine(nums.Sum());
                Console.WriteLine(nums.Min());
            }
            
            // Q11653 - 소인수분해
            int N = int.Parse(Console.ReadLine());
            int i = 2;
            while (N > 1)
            {
                if (N % i == 0)
                {
                    N /= i;
                    Console.WriteLine(i);
                }
                else
                {
                    i++;
                }
            }
            
            // Q1929 - 소수 구하기
            string[] MN = Console.ReadLine().Split();
            int M = int.Parse(MN[0]);
            int N = int.Parse(MN[1]);
            List<int> primes = Enumerable.Range(M, N - M + 1).ToList();
            primes.Remove(1);
            for (int i = 2; i <= Convert.ToInt64(Math.Sqrt(N)); i++)
            {
                primes.RemoveAll(s => s % i == 0 && s != i);
            }
            Console.WriteLine(String.Join("\n", primes));
            
            // Q4948 - 베르트랑 공준
            int n;
            while ((n=int.Parse(Console.ReadLine())) != 0)
            {
                List<int> nums = Enumerable.Range(n+1, n).ToList();
                for (int i = 2; i <= Convert.ToInt64(Math.Sqrt(2*n)); i++)
                {
                    nums.RemoveAll(s => s % i == 0 && s != i);
                }
                Console.WriteLine(nums.Count(s => s > n && s <= 2 * n));
            }
            */
            // Q9020 - 골드바흐의 추측
            int T = int.Parse(Console.ReadLine());
            List<int> primes = new List<int>();
            primes.Add(2);
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int L = primes.Count();
                for (int j = primes[L - 1] + 1; j < n - 1; j++)
                {
                    bool isPrime = true;
                    for (int k = 0; k < L; k++)
                    {
                        if (j % primes[k] == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primes.Add(j);
                        L++;
                    }
                }
                for (int l = 0; l < n / 2; l++)
                {
                    if (primes.Contains(n / 2 - l) && primes.Contains(n / 2 + l))
                    {
                        Console.WriteLine("{0} {1}", n / 2 - l, n / 2 + l);
                        break;
                    }
                }
            }
        }
    }
}
