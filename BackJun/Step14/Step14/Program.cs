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

        }
    }
}
