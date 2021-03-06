using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step9 - 팩토리얼 https://www.acmicpc.net/problem/10872

namespace Step9
{
    class Program
    {
        // Q10872 - 팩토리얼
        static int facto(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return n * facto(n - 1);
            }
        }
        // Q10870 - 피보나치 수 5
        static int pibo(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return pibo(n - 1) + pibo(n - 2);
        }
        // Q17478 - 재귀함수가 뭔가요?
        static void whatIsRecursiveFunction(int n, int i = 0)
        {
            string bar = new String('_', 4 * i);
            Console.WriteLine(@"{0}""재귀함수가 뭔가요?""", bar);

            if (n > 0)
            {
                Console.WriteLine(@"{0}""잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.
{0}마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.
{0}그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.""", bar);
                whatIsRecursiveFunction(n - 1, i + 1);
            }
            else
            {
                Console.WriteLine(@"{0}""재귀함수는 자기 자신을 호출하는 함수라네""", bar);
            }
            Console.WriteLine(@"{0}라고 답변하였지.", bar);

        }
        // Q2447 - 별 찍기 - 10
        static List<string> drawStar(int n)
        {
            if (n == 1)
                return new List<string>() { "*" };

            List<string> stars = drawStar(n / 3);
            List<string> L = new List<string>();

            foreach (string star in stars)
                L.Add(String.Join("", Enumerable.Repeat(star, 3)));
            foreach (string star in stars)
                L.Add(star + String.Join("", Enumerable.Repeat(" ", n / 3)) + star);
            foreach (string star in stars)
                L.Add(String.Join("", Enumerable.Repeat(star, 3)));

            return L;
        }

        // Q11729 - 하노이 탑 이동 순서
        static List<string> move(int n, int start, int end)
        {
            List<string> moves = new List<string>();
            if (n == 1)
            {
<<<<<<< HEAD
                moves.Add(String.Format("{0} {1}", start, end));
                return moves;
=======
                return "a";
            }
            else
            {
                return "a";
>>>>>>> e0336b0bfcee4b77424527b842872467988badde
            }
            moves.AddRange(move(n - 1, start, 6 - end - start));
            moves.AddRange(move(1, start, end));
            moves.AddRange(move(n - 1, 6 - end - start, end));

            return moves;
        }
        static void Main(string[] args)
        {
            // Q10872 - 팩토리얼
            /*
            Console.WriteLine(facto(int.Parse(Console.ReadLine())));
            
            // Q10870 - 피보나치 수 5
            Console.WriteLine(pibo(int.Parse(Console.ReadLine())));
            
            // Q17478 - 재귀함수가 뭔가요?
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
            whatIsRecursiveFunction(n);
            
            // Q2447 - 별 찍기 - 10
            Console.WriteLine(String.Join("\n", drawStar(int.Parse(Console.ReadLine()))));
            */
            // Q11729 - 하노이 탑 이동 순서
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine((int)Math.Pow((double)2, (double)N) - 1);
            Console.WriteLine(String.Join("\n", move(N, 1, 3)));
        }
    }
}