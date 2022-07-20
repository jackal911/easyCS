using System;
using System.Linq;
using System.Collections.Generic;

namespace MakePrime
{
    class Solution
    {
        List<int> PrimeSet = new List<int>() {2};
        IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        bool isPrime(int num)
        {
            if (PrimeSet.Max() < num)
            {
                for (int i = PrimeSet.Max() + 1; i <= num; i++)
                {
                    if (i % 2 == 0)
                        continue;

                    bool isIPrime = true;
                    foreach (int prime in PrimeSet)
                    {
                        if (i % prime == 0)
                        {
                            isIPrime = false;
                            break;
                        }
                    }
                    if (isIPrime)
                        PrimeSet.Add(i);
                }
            }
            return PrimeSet.Contains(num);
        }

        public int solution(int[] nums)
        {
            int answer = 0;
            foreach (var s in GetKCombs(nums, 3))
            {
                if (isPrime(s.Sum()))
                    answer++;
            }            
            return answer;
        }
    }
    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 1, 2, 7, 6, 4 };
            Console.WriteLine(s.solution(nums));
//             foreach (var v in GetKCombs<int>(nums, 3))
//             {
//                 v.ToList().ForEach(x => Console.Write(x + " "));
//                 Console.WriteLine();
//             }

        }
    }
}
