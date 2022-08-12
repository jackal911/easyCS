using System;
using System.Linq;

// Step1 - 입출력과 사칙연산 https://www.acmicpc.net/step/1

namespace Step1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q2557 - Hello World
            Console.WriteLine("Hello World!");

            // Q10718 - We love kriii
            Console.WriteLine("강한친구 대한육군");
            Console.WriteLine("강한친구 대한육군");
            

            // Q10171 - 고양이
            Console.Write(@"\    /\
 )  ( ')
(  /  )
 \(__)|");
            
            // Q10172 - 개
            // Console.WriteLine("|\\_/|");
            // Console.WriteLine("|q p|   /}");
            // Console.WriteLine("( 0 )\"\"\"\\");
            // Console.WriteLine("|\"^\"`    |");
            // Console.WriteLine("||_/=\\\\__|");

            Console.Write(@"|\_/|
|q p|   /}
( 0 )""""""\
|""^""`    |
||_/=\\__|");
            
            // Q1000 - A+B
            string[] nums = Console.ReadLine().Split();
            int A = int.Parse(nums[0]);
            int B = int.Parse(nums[1]);
            Console.WriteLine(A + B);
            

            // Q1001 - A-B
            string[] nums = Console.ReadLine().Split();
            int A = int.Parse(nums[0]);
            int B = int.Parse(nums[1]);
            Console.Write(A - B);
            

            // Q10998 - AXB
            string[] nums = Console.ReadLine().Split();
            int A = int.Parse(nums[0]);
            int B = int.Parse(nums[1]);
            Console.Write(A * B);
            

            // Q1008 - A/B
            string[] nums = Console.ReadLine().Split();
            int A = int.Parse(nums[0]);
            double B = double.Parse(nums[1]);
            Console.Write(A / B);
            

            // Q10869 - 사칙연산
            string[] nums = Console.ReadLine().Split();
            int A = int.Parse(nums[0]);
            int B = int.Parse(nums[1]);
            Console.WriteLine(A + B);
            Console.WriteLine(A - B);
            Console.WriteLine(A * B);
            Console.WriteLine(A / B);
            Console.WriteLine(A % B);
            

            // Q10926 - ??!
            string A = Console.ReadLine();
            Console.WriteLine(A + "??!");
            

            // Q18108 - 1998년생인 내가 태국에서는 2541년생?!
            int y = int.Parse(Console.ReadLine());
            Console.Write(y - 543);
            */
            // Q3003 - 킹, 퀸, 룩, 비숍, 나이트, 폰
            int[] original = { 1, 1, 2, 2, 2, 8 };
            int[] current = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine(String.Join(" ", current.Select((v, i) => original[i] - v)));
            /*
            // Q10430 - 나머지
            string[] inp = Console.ReadLine().Split();
            int A = int.Parse(inp[0]);
            int B = int.Parse(inp[1]);
            int C = int.Parse(inp[2]);
            Console.WriteLine((A + B) % C);
            Console.WriteLine(((A % C) + (B % C)) % C);
            Console.WriteLine((A * B) % C);
            Console.WriteLine(((A % C) * (B % C)) % C);
            

            // Q2588 - 곱셈
            int A = int.Parse(Console.ReadLine());
            string B = Console.ReadLine();
            int x = A * (B[2] - 48);
            int y = A * (B[1] - 48);
            int z = A * (B[0] - 48);
            string outp = String.Format("{0}\n{1}\n{2}\n{3}", x, y, z, x + y * 10 + z * 100);
            Console.WriteLine(outp);
            */

            // Q25083 - 새싹
            Console.Write(@"         ,r'""7
r`-_   ,'  ,/
 \. "". L_r'
   `~\/
      |
      |");
        }
    }
}
