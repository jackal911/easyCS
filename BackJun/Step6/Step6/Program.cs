using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step6 - 문자열 https://www.acmicpc.net/step/7

namespace Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
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
            
            // Q1157 - 단어 공부
            List<char> input = Console.ReadLine().ToUpper().ToList();
            List<char> chars = new List<char>();
            List<int> counts = new List<int>();
            while (input.Count != 0)
            {
                char ch = input[0];
                chars.Add(ch);                
                int n = input.RemoveAll(s => s == ch);
                counts.Add(n);
            }
            int maxIndex = counts.IndexOf(counts.Max());
            if (counts.FindAll(s => s==counts.Max()).Count!=1)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(chars[maxIndex]);
            }
            
            // Q1152 - 단어의 개수
            List<string> inp = Console.ReadLine().Trim().Split().ToList();
            if (inp[0] == "")
            {
                inp.RemoveAt(0);
            }
            Console.WriteLine(inp.Count);
            
            // Q2908 - 상수
            string[] inp = String.Join("", Console.ReadLine().ToArray().Reverse().ToArray()).Split();
            Console.WriteLine(Math.Max(int.Parse(inp[0]), int.Parse(inp[1])));
            
            // Q5622 - 다이얼
            List<char> inp = Console.ReadLine().ToList();
            int time = 0;
            foreach (var ch in inp)
            {
                if (ch > 'V')
                {
                    time += 10;
                }
                else if (ch > 'S')
                {
                    time += 9;
                }
                else if (ch > 'O')
                {
                    time += 8;
                }
                else if (ch > 'L')
                {
                    time += 7;
                }
                else if (ch > 'I')
                {
                    time += 6;
                }
                else if (ch > 'F')
                {
                    time += 5;
                }
                else if (ch > 'C')
                {
                    time += 4;
                }
                else
                {
                    time += 3;
                }
            }
            Console.WriteLine(time);
            
            // Q2941 - 크로아티아 알파벳
            string inp = Console.ReadLine();
            string[] croAls = { "c=", "c-", "dz=", "d-", "lj", "nj", "s=", "z=" };
            foreach (var croAl in croAls)
            {
                inp = inp.Replace(croAl, "a");
            }
            Console.WriteLine(inp.Length);
            */
            // Q1316 - 그룹 단어 체커
            int N = int.Parse(Console.ReadLine());
            int count = 0;            
            for (int i = 0; i < N; i++)
            {
                bool isGroupWrod = true;
                List<char> temp = new List<char>();
                string str = Console.ReadLine();
                char toCompare = '-';
                for (int j = 0; j < str.Length; j++)
                {
                    if (toCompare != str[j])
                    {
                        if (temp.Contains(str[j]))
                        {
                            isGroupWrod = false;
                            break;
                        }
                        else
                        {
                            temp.Add(str[j]);
                        }
                    }
                    toCompare = str[j];
                }
                if (isGroupWrod)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
