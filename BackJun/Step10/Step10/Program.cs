using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step10 - 브루트 포스 https://www.acmicpc.net/step/22

namespace Step10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q2798 - 블랙잭
            int M;
            string[] inp = Console.ReadLine().Split();
            M = int.Parse(inp[1]);
            int[] nums = Console.ReadLine().Split().ToList().ConvertAll(int.Parse).ToArray();
            int len = nums.Length;
            int max = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    for (int k = j + 1; k < len; k++)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        if (sum >= max && sum <= M)
                        {
                            max = sum;
                        }
                    }
                }
            }
            Console.WriteLine(max);
            
            // Q2231 - 분해합
            int N = int.Parse(Console.ReadLine());
            int genNum = 0;
            for (int i = Math.Max(N - 54, 0); i < N; i++)
            {
                int dismissSum = i + i.ToString().ToList().ConvertAll(s => (char)s - 48).ToList().Sum();
                if (dismissSum == N)
                {
                    genNum = i;
                    break;
                }
            }
            Console.WriteLine(genNum);
            
            // Q7568 - 덩치
            int N = int.Parse(Console.ReadLine());
            int[][] wh = new int[N][];
            int[] grade = new int[N];
            for (int i = 0; i < N; i++)
            {
                wh[i] = Console.ReadLine().Split().ToList().ConvertAll(int.Parse).ToArray();
                grade[i] = 1;
            }
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++)
                {
                    if (wh[k][0] > wh[j][0] && wh[k][1] > wh[j][1])
                        grade[j]++;
                }
            }
            Console.WriteLine(String.Join(" ", grade));
            */
            // Q1018 - 체스판 다시 칠하기
            List<int> NM = Console.ReadLine().Split().ToList().ConvertAll(int.Parse).ToList();
            List<string> chessBoard = new List<string>();
            char[] WB = new char[]{'W', 'B'};
            int index = 0;
            int bigIndex = 0;
            int ifW, ifB;
            int min = 1300;
            for (int i = 0; i < NM[0]; i++)
            {
                chessBoard.Add(Console.ReadLine());
            }

            for (int j = 0; j < NM[0]-8; j++)
            {
                for (int m = 0; m < NM[1]-8; m++)
                {
                    ifW = 0;
                    ifB = 0;
                    for (int k = j; k < j+8; k++)
                    {
                        index = bigIndex;
                        for (int l = m; l < m+8; l++)
                        {                            
                            if (chessBoard[k][l] != WB[index])
                                ifW++;
                            if (chessBoard[k][l] != WB[1 - index])
                                ifB++;
                            Console.WriteLine("{0} : {1} {2}", chessBoard[k][l], ifW, ifB);
                            index = 1 - index;
                        }
                        bigIndex = 1 - bigIndex;
                    }
                    min = Math.Min(Math.Min(ifW, ifB), min);
                }                
            }        
            
            Console.WriteLine(min);
        }
    }
}
