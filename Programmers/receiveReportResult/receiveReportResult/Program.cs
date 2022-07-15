using System;
using System.Collections.Generic;
using System.Linq;

namespace receiveReportResult
{
    public class Solution
    {
        public int[] solution(string[] id_list, string[] report, int k)
        {
            var tReport1 = report.Distinct();
            var tReport2 = tReport1.Select(s => s.Split(' '));
            var tReport3 = tReport2.GroupBy(g => g[1]);
            var tReport4 = tReport3.Where(w => w.Count() >= k);
            var tReport5 = tReport4.SelectMany(sm => sm.Select(s => s[0]));
            var tReport6 = tReport5.ToList();

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
            string[] id_list = { "con", "ryan" };
            string[] report = { "ryan con", "ryan con", "ryan con", "ryan con" };
            int k = 3;
            Array.ForEach(s.solution(id_list, report, k), x => Console.WriteLine(x));
        }
    }
}
