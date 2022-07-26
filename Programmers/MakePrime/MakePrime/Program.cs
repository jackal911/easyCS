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
<<<<<<< HEAD
        static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            IEnumerable<IEnumerable<T>> k = GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
            return k;
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            foreach (var v in GetKCombs<int>(nums, 3))
            {
                v.ToList().ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
            }
            //
            PetOwner[] petOwners =
            { new PetOwner { Name="Higa",
                  Pets = new List<string>{ "Scruffy", "Sam" } },
              new PetOwner { Name="Ashkenazi",
                  Pets = new List<string>{ "Walker", "Sugar" } },
              new PetOwner { Name="Price",
                  Pets = new List<string>{ "Scratches", "Diesel" } },
              new PetOwner { Name="Hines",
                  Pets = new List<string>{ "Dusty" } } };

            // Project the pet owner's name and the pet's name.
            var query =
                petOwners
                .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName }) // 이중구조로 되어있는 PetOwner의 Pets 리스트를 풀어서 petOwner와 함께 anonymous type으로 묶는다.
                .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S")) // pet 이름이 S로 시작하는 멤버만 살린다.
                .Select(ownerAndPet =>
                        new List<string>()
                        {
                            ownerAndPet.petOwner.Name,
                            ownerAndPet.petName
                        }
                ); // anonymous type으로 되어있는 각각의 멤버를 풀고 petOwner 객체에서 owner의 name만 빼서 다시 anonymous type으로 묶는다.

            // Print the results.
            foreach (var obj in query)
            {
                Console.WriteLine(obj); // anonymous type은 조회도 깔끔하게 잘된다.
            }
            Dictionary<string, string> dict = new Dictionary<string, string>() { { "a", "b" } };
            Console.WriteLine(dict["a"]);
            Console.WriteLine();
=======
        
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

>>>>>>> 6ad0150df01da262fc98673dcc81565c47614e43
        }
    }
}
