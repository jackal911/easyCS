using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step5 - 함수 https://www.acmicpc.net/step/5

namespace Step5
{

    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q4673 - 셀프 넘버
            List<int> nums = Enumerable.Range(1, 10000).ToList();
            for (int i = 1; i <= 10000; i++)
            {
                string iStr = i.ToString();
                int dn = i + Array.ConvertAll(iStr.ToArray(), s => (int)s-48).Sum();
                nums.Remove(dn);
            }
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            */
            // Q1065 - 한수
            int N = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                if(i<100){
                    count++;
                    continue;
                }
                string iStr = i.ToString();
                bool hansuOrNot = true;
                for (int j = 0; j < iStr.Length - 2; j++)
                {
                    if (iStr[j] - iStr[j + 1] != iStr[j + 1] - iStr[j + 2])
                    {
                        hansuOrNot = false;
                        break;
                    }
                }
                if (hansuOrNot)
                {
                    count++;
                }
            }
            Console.WriteLine(count);            
        }
    }
}
