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
            
            // Q11654 - 아스키 코드
            Console.Write((int)Console.ReadLine()[0]);
            
            // Q11720 - 숫자의 합
            int N = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().ToArray(), s => (int)s - 48);
            Console.WriteLine(nums.Sum());
            
            // Q10809 - 알파벳 찾기
            string S = Console.ReadLine();
            for (char i = 'a'; i <= 'z'; i++)
            {
                Console.Write(S.IndexOf(i)+" ");
            }
            
            // Q2675 - 문자열 반복
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string[] inp = Console.ReadLine().Split();
                int R = int.Parse(inp[0]);
                string[] result = Array.ConvertAll(inp[1].ToArray(), s => String.Join("", Enumerable.Repeat(s, R).ToArray()));
                string resultFinal = String.Join("", result);
                Console.WriteLine(resultFinal);
            }
            */
            // Q1157 - 단어 공부
            List<char> input = Console.ReadLine().ToUpper().ToList();
            //while(input.Length!=0)
            input.Count(s => s == input[0]);
        }
    }
}
