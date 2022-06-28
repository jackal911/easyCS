using System;
using System.Linq;

// Step2 - 조건문 https://www.acmicpc.net/step/4

namespace Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            // Q1330 - 두 수 비교하기
            string[] inp = Console.ReadLine().Split();
            int A = int.Parse(inp[0]);
            int B = int.Parse(inp[1]);
            if (A > B)
            {
                Console.Write('>');
            }
            else if (A < B)
            {
                Console.Write('<');
            }
            else
            {
                Console.Write("==");
            }
            

            // Q9498 - 시험 성적
            // int inp = int.Parse(Console.ReadLine());
            // if (inp >= 90)
            // {
            //     Console.Write("A");
            // }
            // else if (inp >= 80)
            // {
            //     Console.Write("B");
            // }
            // else if (inp >= 70)
            // {
            //     Console.Write("C");
            // }
            // else if (inp >= 60)
            // {
            //     Console.Write("D");
            // }
            // else
            // {
            //     Console.Write("F");
            // }
            int s = int.Parse(Console.ReadLine());
            Console.Write(s > 89 ? "A" : s > 79 ? "B" : s > 69 ? "C" : s > 59 ? "D" : "F");
            

            // Q2753 - 윤년
            int inp = int.Parse(Console.ReadLine());
            if ((inp % 4 == 0 && inp % 100 != 0) || inp % 400 == 0)
            {
                Console.Write(1);
            }
            else
            {
                Console.Write(0);
            }
            

            // Q14681 - 사분면 고르기
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Console.Write(x > 0 ? (y > 0 ? 1 : 4) : (y > 0 ? 2 : 3));
            

            // Q2884 - 알람 시계
            string[] inp = Console.ReadLine().Split();
            int h = int.Parse(inp[0]);
            int m = int.Parse(inp[1]);
            DateTime curTime = new DateTime(2000, 6, 30, h, m, 0);
            DateTime changedTime = curTime.AddMinutes(-45);
            string outp = String.Format("{0} {1}", changedTime.Hour, changedTime.Minute);
            Console.Write(outp);
            
            // Q2525 - 오븐 시계            
            string[] inp = Console.ReadLine().Split();
            int h = int.Parse(inp[0]);
            int m = int.Parse(inp[1]);
            int elapsedTime = int.Parse(Console.ReadLine());
            DateTime curTime = new DateTime(2000, 6, 30, h, m, 0);
            DateTime changedTime = curTime.AddMinutes(elapsedTime);
            string outp = String.Format("{0} {1}", changedTime.Hour, changedTime.Minute);
            Console.Write(outp);
            */

            // Q2480 - 주사위 세개
            string[] inp = Console.ReadLine().Split();
            Array.Sort(inp);
            int A = int.Parse(inp[0]);
            int B = int.Parse(inp[1]);
            int C = int.Parse(inp[2]);
            Console.Write(A==B ? (B==C ? 10000+A*1000 : 1000+A*100):(B==C ? 1000+B*100 : C*100));
        }
    }
}
