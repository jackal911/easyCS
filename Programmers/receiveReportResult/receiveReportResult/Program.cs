using System;
using System.Collections.Generic;
using System.Linq;

namespace receiveReportResult
{
    public class Solution
    {
        public int[] solution(string[] id_list, string[] report, int k)
        {
            var tReport1 = report.Distinct().
                Select(s => s.Split(' ')).
                GroupBy(g => g[1]).
                Where(w => w.Count() >= k);
            foreach (var str in tReport1)
            {
                foreach (var s in str)
                {
                    foreach (var _ in s)
                    {
                        Console.Write(_ + "\n");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------");
            }

            var tReport = report.Distinct().
                Select(s => s.Split(' ')).
                GroupBy(g => g[1]).
                Where(w => w.Count() >= k).
                SelectMany(sm => sm.Select(s => s[0])).
                ToList();

            return id_list.ToDictionary(x => x, x => tReport.Count(c => x == c)).Values.ToArray();
//             int length = id_list.Length;
//             int[] answer = new int[length];
//             int[][] reported = new int[length][];
//             for (int i = 0; i < length; i++)
//             {
//                 reported[i] = new int[length];
//             }
//             foreach (string rep in report)
//             {
//                 string[] reporterAndReported = rep.Split();
//                 int reporterIndex = Array.IndexOf(id_list, reporterAndReported[0]);
//                 int reportedIndex = Array.IndexOf(id_list, reporterAndReported[1]);
//                 if(reportedIndex!=reporterIndex)
//                     reported[reportedIndex][reporterIndex] = 1;
//             }
//             List<int> forbiddenUser = new List<int>();
//             foreach (int[] reporter in reported)
//             {
//                 if (Enumerable.Sum(reporter) >= k)
//                 {
//                     for (int i = 0; i < length; i++)
//                     {
//                         answer[i] += reporter[i];
//                     }
//                 }
//             }
//             return answer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string[] id_list = { "muzi", "frodo", "apeach", "neo" };
            string[] report = { "muzi frodo", "apeach frodo", "frodo neo", "muzi neo", "apeach muzi" };
            int k = 2;
            Array.ForEach(s.solution(id_list, report, k), x => Console.WriteLine(x));
        }
    }
}
