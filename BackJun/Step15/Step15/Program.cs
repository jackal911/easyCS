using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Step15
{
    // Step15 - 백트래킹
    class Program
    {
        // Q15649 - N과 M (1)
        static void printPermutation(int M, List<int> lst, List<bool> visit, List<int> result, StreamWriter sw)
        {            
            if (M == result.Count)
            {
                result.ForEach(s => sw.Write(s + " "));
                sw.WriteLine();
            }
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if (visit[i] == false)
                    {
                        result.Add(lst[i]);
                        visit[i] = true;
                        printPermutation(M, lst, visit, result, sw);
                        visit[i] = false;
                        result.Remove(lst[i]);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // Q15649 - N과 M (1)
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> nums = Enumerable.Range(1, NM[0]).ToList();
            List<bool> visit = Enumerable.Repeat(false, NM[0]).ToList();
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            printPermutation(NM[1], nums, visit, new List<int>(), sw);
            sw.Close();

            // Q15650 - N과 M (2)


            // Q15651 - N과 M (3)


            // Q15652 - N과 M (4)


            // Q9663 - N-Queen


            // Q2580 - 스도쿠

            
            // Q14888 - 연산자 끼워넣기


            // Q14889 - 스타트와 링크


        }
    }
}
