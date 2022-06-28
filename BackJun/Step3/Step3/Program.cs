using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Step3 - 반복문 https://www.acmicpc.net/step/3

namespace Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q2739 - 구구단
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i < 10; i++)
            {
                string outp = String.Format("{0} * {1} = {2}", N, i, N * i);
                Console.WriteLine(outp);
            }
            

            // Q10950 - A+B - 3
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inp = Console.ReadLine().Split();
                int A = int.Parse(inp[0]);
                int B = int.Parse(inp[1]);
                Console.WriteLine(A+B);
            }
            
            // Q8393 - 합
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum += i;
            }
            Console.Write(sum);
            
            // Q15552 - 빠른 A+B
            int T = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                string[] inp = Console.ReadLine().Split();
                int A = int.Parse(inp[0]);
                int B = int.Parse(inp[1]);
                sb.AppendLine((A + B).ToString());
            }
            Console.Write(sb.ToString());
            
            // Q2741 - N 찍기
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                sb.AppendLine(i.ToString());
            }
            Console.WriteLine(sb);
            */
            // Q2742 - 기찍 N
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            for (int i = N; i >= 1; i--)
            {
                sb.AppendLine(i.ToString());
            }
            Console.Write(sb);
        }
    }
}
