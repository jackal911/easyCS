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
            */
            // Q25304 - 영수증
            int X = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            while (N-- > 0)
            {
                int[] ab = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                X -= ab[0] * ab[1];
            }
            if (X == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            /*
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
            
            // Q2742 - 기찍 N
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            for (int i = N; i >= 1; i--)
            {
                sb.AppendLine(i.ToString());
            }
            Console.Write(sb);
            
            // Q11021 - A+B - 7
            int? T = int.Parse(Console.ReadLine());
            for (var i = 1; i <= T; i++)
            {
                string inp = Console.ReadLine();
                Console.WriteLine("Case #{0}: {1}", i, inp[0] + inp[2] - 96);
            }
            // Q11022 - A+B - 8
            int? T = int.Parse(Console.ReadLine());
            for (var i = 1; i <= T; i++)
            {
                string inp = Console.ReadLine();
                Console.WriteLine("Case #{0}: {1} + {2} = {3}", i, inp[0]-48, inp[2]-48, inp[0] + inp[2] - 96);
            }
            
            // Q2438 - 별 찍기 - 1
            int T = int.Parse(Console.ReadLine());
            string stars = "";
            for (var i = 0; i < T; i++)
            {
                stars += "*";
                Console.WriteLine(stars);
            }
            
            // Q2439 - 별 찍기 - 2
            int T = int.Parse(Console.ReadLine());
            string stars = "";
            for (var i = 0; i < T; i++)
            {
                stars += "*";
                Console.WriteLine("{0, "+T+"}", stars);
                //Console.WriteLine(stars.PadLeft(T));
            }
            
            // Q10871 - X보다 작은 수
            string[] inp = Console.ReadLine().Split();
            int N = int.Parse(inp[0]);
            int X = int.Parse(inp[1]);
            string[] nums = Console.ReadLine().Split();
            foreach (var num in nums)
            {
                int n = int.Parse(num);
                if (n < X)
                {
                    Console.Write(n + " ");
                }
            }
            
            // Q10952 - A+B - 5
            while (true)
            {
                string inp = Console.ReadLine();
                if (inp[0] == '0' && inp[2] == '0')
                {
                    break;
                }
                else
                {
                    Console.WriteLine(inp[0] + inp[2] - 96);
                }
            }
            
            // Q10951 - A+B - 4
            while (true)
            {
                string inp;
                try
                {
                    inp = Console.ReadLine();
                    Console.WriteLine(inp[0] + inp[2] - 96); 
                }
                catch
                {
                    break;
                }                               
            }
            
            // Q1110 - 더하기 사이클
            int N = int.Parse(Console.ReadLine());
            int temp = (N % 10 + N / 10)%10 + (N % 10) * 10;
            int i = 1;
            while (temp != N)
            {
                temp = (temp % 10 + temp / 10)%10 + (temp % 10) * 10;
                i++;
            }
            Console.WriteLine(i);
            */
        }
    }
}
