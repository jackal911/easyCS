using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step10 - 브루트 포스 https://www.acmicpc.net/step/22

namespace Step10
{
    class Program
    {
        // Q2751 - 수 정렬하기 2
        // 합병정렬 ver
        static List<int> mergeSort(List<int> lst)
        {
            if (lst.Count < 2)
            {
                return lst;
            }
            else if (lst.Count == 2)
            {
                if (lst[0] > lst[1])
                {
                    int temp = lst[1];
                    lst[1] = lst[0];
                    lst[0] = temp;
                }
                return lst;
            }
            else
            {
                List<int> divided1 = lst.GetRange(0, lst.Count / 2);
                lst.RemoveAll(s => divided1.Contains(s));
                divided1 = mergeSort(divided1);
                lst = mergeSort(lst);
                List<int> newList = new List<int>();
                while (divided1.Count != 0 || lst.Count != 0)
                {
                    if (divided1.Count != 0)
                    {
                        if (lst.Count != 0)
                        {
                            if (lst[0] > divided1[0])
                            {
                                newList.Add(divided1[0]);
                                divided1.RemoveAt(0);
                            }
                            else
                            {
                                newList.Add(lst[0]);
                                lst.RemoveAt(0);
                            }
                        }
                        else
                        {
                            newList.Add(divided1[0]);
                            divided1.RemoveAt(0);
                        }
                    }
                    else
                    {
                        newList.Add(lst[0]);
                        lst.RemoveAt(0);
                    }
                }
                return newList;
            }
        }
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

            for (int j = 0; j < NM[0]-7; j++)
            {
                for (int m = 0; m < NM[1]-7; m++)
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
                            index = 1 - index;
                        }
                        bigIndex = 1 - bigIndex;
                    }
                    min = Math.Min(Math.Min(ifW, ifB), min);
                }                
            }        
            
            Console.WriteLine(min);
            
            // Q1436 - 영화감독 숌
            List<long> nums = new List<long>();
            string threeSix = "666";
            for (int i = 0; i < 10000; i++)
            {
                string strI = i.ToString();
                for (int j = 0; j <= strI.Length; j++)
                {                    
                    string mixup = strI.Substring(0, j) + threeSix + strI.Substring(j);
                    nums.Add(long.Parse(mixup));
                }
            }

            threeSix = "6660";
            for (int k = 0; k < 1000; k++)
            { 
                string strK = threeSix + k.ToString();
                nums.Add(long.Parse(strK));
            }

            threeSix = "66600";
            for (int l = 0; l < 100; l++)
            {
                string strL = threeSix + l.ToString();
                nums.Add(long.Parse(strL));
            }

            threeSix = "666000";
            for (int m = 0; m < 10; m++)
            {
                string strM = threeSix + m.ToString();
                nums.Add(long.Parse(strM));
            }

            int index = int.Parse(Console.ReadLine());
            nums = nums.Distinct().ToList();
            nums.Sort();
            Console.WriteLine(nums[index-1]);
            
            // Q2750 - 수 정렬하기
            // 버블정렬 ver
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int j = N-1; j > 0; j--)
            {
                for (int k = 0; k < N - 1; k++)
                {
                    if (nums[k] > nums[k + 1])
                    {
                        int temp = nums[k];
                        nums[k] = nums[k + 1];
                        nums[k + 1] = temp;
                    }
                }
            }
            for (int l = 0; l < N; l++)
                Console.WriteLine(nums[l]);
            
            // 삽입정렬 ver
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 1; i < N; i++)
            {
                int key = nums[i];
                int insert = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (key < nums[j])
                    {
                        nums[j + 1] = nums[j];
                        insert = j;
                    }
                    else
                    {
                        insert = j + 1;
                        break;
                    }
                }
                nums[insert] = key;
            }
            for (int k = 0; k < N; k++)
                Console.WriteLine(nums[k]);
            
            // Q2751 - 수 정렬하기 2
            // 합병정렬 ver - 시간초과
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }
            nums = mergeSort(nums);

            StringBuilder sb = new StringBuilder(String.Join("\n", nums));
            
            Console.WriteLine(sb);

            // 내장함수 ver
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }
            nums.Sort();
            for (int i = 0; i < N; i++)
            {
                sb.Append(String.Format("{0}\n", nums[i]));
            }
            Console.WriteLine(sb.ToString());
            
            // Q10989 - 수 정렬하기 3
            // 카운팅 정렬 ver - 메모리초과
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }
            int max = nums.Max();
            List<int> count = Enumerable.Repeat(0, max + 1).ToList();

            foreach (var num in nums)
                count[num]++;

            
            for (int i = 0; i < max; i++)
            {
                count[i + 1] += count[i];
            }
            int[] result = new int[N];
            foreach (var num in nums)
            {
                result[count[num]-1] = num;
                count[num]--;
            }

            StringBuilder sb = new StringBuilder(String.Join("\n", result));

            Console.WriteLine(sb);
            
            // 내장함수 ver - 시간초과
            int N = int.Parse(Console.ReadLine());
            int[] count = new int[10001];
            for (int i = 0; i < N; i++)
            {
                count[int.Parse(Console.ReadLine())]++;
            }
            int curIndex = 1;
            StringBuilder sb = new StringBuilder();
            while (curIndex < 10001)
            {
                if (count[curIndex] > 0)
                {
                    sb.Append(String.Format("{0}\n", curIndex));
                    count[curIndex]--;
                }
                else
                    curIndex++;
            }
            Console.WriteLine(sb);
            */
            // Q2108 - 통계학
            string temp = Console.ReadLine();
            int cnt = Int32.Parse(temp);

            int[] arr = new int[cnt];

            for (int i = 0; i < cnt; i++)
            {
                temp = Console.ReadLine();
                arr[i] = Int32.Parse(temp);
            }

            Array.Sort(arr);

            List<int> choibin = new List<int>();
            int choibinResult = 0;
            int count = 0;
            foreach (var item in arr.GroupBy(s => s))
            {
                if (item.Count() > count)
                {                    
                    count = item.Count();
                    choibin.Clear();
                    choibin.Add(item.Key);
                }
                else if (item.Count() == count)
                {
                    choibin.Add(item.Key);
                }
            }

            choibinResult = choibin.Count > 1 ? choibin[1] : choibin[0];
            Console.WriteLine(Math.Round(arr.Average()));
            Console.WriteLine(arr[arr.Length / 2]);
            Console.WriteLine(choibinResult);
            Console.WriteLine(arr.Max() - arr.Min());
        }
    }
}
