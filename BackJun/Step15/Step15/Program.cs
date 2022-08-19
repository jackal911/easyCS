using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Step15
{
    // Step15 - 백트래킹
    class Program
    {
        // Q15649 - N과 M (1)
        static void printPermutation(int M, List<int> lst, List<bool> visit, List<int> result, StreamWriter sw)
        {            
            if (M == result.Count)
            {
                result.ForEach(s => sw.Write(s + " "));
                sw.WriteLine();
            }
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if (visit[i] == false)
                    {
                        result.Add(lst[i]);
                        visit[i] = true;
                        printPermutation(M, lst, visit, result, sw);
                        visit[i] = false;
                        result.Remove(lst[i]);
                    }
                }
            }
        }

        // Q15650 - N과 M (2)
        static void printCombination(int N, int M, List<int> nums, List<int> result, int count, StreamWriter sw)
        {
            if (result.Count == M)
            {
                foreach (int e in result)
                {
                    sw.Write(e + " ");
                }
                sw.WriteLine();
            }
            else
            {
                for (int i = count; i < nums.Count; i++)
                {
                    count = i;
                    result.Add(nums[i]);
                    count++;
                    printCombination(N, M, nums, result, count, sw);
                    result.Remove(nums[i]);
                }
            }
        }

        // Q15651 - N과 M (3)
        static void printRepeatedPermutation(int M, List<int> lst, List<int> result, StreamWriter sw)
        {
            if (M == result.Count)
            {
                result.ForEach(s => sw.Write(s + " "));
                sw.WriteLine();
            }
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    result.Add(lst[i]);
                    printRepeatedPermutation(M, lst, result, sw);
                    result.RemoveAt(result.Count-1);
                }
            }
        }

        // Q15652 - N과 M (4)
        static void printRepeatedCombination(int N, int M, List<int> nums, List<int> result, int count, StreamWriter sw)
        {
            if (result.Count == M)
            {
                foreach (int e in result)
                {
                    sw.Write(e + " ");
                }
                sw.WriteLine();
            }
            else
            {
                for (int i = count; i < nums.Count; i++)
                {
                    count = i;
                    result.Add(nums[i]);                    
                    printRepeatedCombination(N, M, nums, result, count, sw);
                    result.Remove(nums[i]);
                }
            }
        }

        // Q9663 - N-Queen
        static void checkDeadZone(int[,] chessBoard, int row, int col)
        {
            int N = chessBoard.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == row || j == col || Math.Abs(i-row) == Math.Abs(j-col))
                    {
                        chessBoard[i,j]++;						
                    }
                }
            }
        }
		static void releaseDeadZone(int[,] chessBoard, int row, int col)
		{
			int N = chessBoard.GetLength(0);
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (i == row || j == col || Math.Abs(i - row) == Math.Abs(j - col))
					{
						chessBoard[i,j]--;
					}
				}
			}
		}
		static int NQueen(int[,] chessBoard, int[,] points, ref int chessCount, int startRow = 0, int completeCount = 0)
        {
            //int[,] preChessBoard; 
            int N = chessBoard.GetLength(0);
            for (int i = startRow; i < N; i++)
            {
				bool isZeroExist = false;
                for (int j = 0; j < N; j++)
                {
                    if (chessBoard[i,j] == 0)
                    {
						isZeroExist = true;
                        chessCount++;
                        if (chessCount == N)
                        {
                            completeCount++;							
							isZeroExist = false;
							Console.WriteLine(getPointsPicture(points));
							//Console.WriteLine(chessBoardToString(chessBoard));
							//Console.WriteLine("Sucess {0}\n", completeCount);
                        }
                        else
                        {
							//int[,] tempChessBoard = (int[,])chessBoard.Clone();
							//Array.Copy(chessBoard, tempChessBoard, 0);
                            //preChessBoard = new int[,]();
                            //chessBoard.Keys.ToList().ForEach(s=> preChessBoard.Add(s, Array.ConvertAll(chessBoard[s], x=>x)));
                            checkDeadZone(chessBoard, i, j);
							points[i, j]++;
                            //Console.WriteLine(chessBoardToString(chessBoard)); // 삭제 필요
							completeCount = NQueen(chessBoard, points, ref chessCount, i + 1, completeCount);
							//chessBoard = (int[,])tempChessBoard.Clone();
							//Array.Copy(tempChessBoard, chessBoard, 0);
							releaseDeadZone(chessBoard, i, j);
							points[i, j]--;
                            //preChessBoard.Keys.ToList().ForEach(s => preChessBoard[s].CopyTo(chessBoard[s], 0)); // 원상복구
                        }
                        chessCount--;
                    }
                }
				if (isZeroExist == false)
				{
					break;
				}
            }            
            //Console.WriteLine();
            return completeCount;
        }
        static string chessBoardToString(int[,] chessBoard)
        {            
            string result = "";
			int N = chessBoard.GetLength(0);
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					result += chessBoard[i,j];
				}
				result += "\n";
			}
//             foreach (var row in chessBoard)
//             {
//                 foreach (int count in row)
//                 {
//                     result += count;
//                 }
//                 result += "\n";
//             }
			return result;
		}
		static string getPointsPicture(int[,] points)
		{
			string result = "";
			int N = points.GetLength(0);
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (points[i, j] == 1)
					{
						result += "1";
					}
					else
					{
						result += "0";
					}
				}
				result += "\n";
			}
			return result;
		}

        static void Main(string[] args)
        {
            /*
            // Q15649 - N과 M (1)
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> nums = Enumerable.Range(1, NM[0]).ToList();
            List<bool> visit = Enumerable.Repeat(false, NM[0]).ToList();
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            printPermutation(NM[1], nums, visit, new List<int>(), sw);
            sw.Close();
            
            // Q15650 - N과 M (2)
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> nums = Enumerable.Range(1, NM[0]).ToList();
            int count = 0;
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            printCombination(NM[0], NM[1], nums, new List<int>(), count, sw);
            sw.Close();
            
            // Q15651 - N과 M (3)
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> nums = Enumerable.Range(1, NM[0]).ToList();
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            printRepeatedPermutation(NM[1], nums, new List<int>(), sw);
            sw.Close();
            
            // Q15652 - N과 M (4)
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> nums = Enumerable.Range(1, NM[0]).ToList();
            int count = 0;
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            printRepeatedCombination(NM[0], NM[1], nums, new List<int>(), count, sw);
            sw.Close();
            */
            // Q9663 - N-Queen
            int N = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = new Stopwatch(); //객체 선언
            stopwatch.Start(); // 시간측정 시작

            int[,] chessBoard = new int[N,N];
			int[,] points = new int[N, N];
//             for (int i = 0; i < N; i++)
//             {
//                 chessBoard.Add(Enumerable.Repeat(0, N).ToList());
//             }
            int chessCount = 0;
			Console.WriteLine(NQueen(chessBoard, points, ref chessCount));

            stopwatch.Stop(); //시간측정 끝

            System.Console.WriteLine("time : " +
                               stopwatch.ElapsedMilliseconds + "ms");
            
//             foreach (var row in chessBoard)
//             {
//                 foreach (int box in row)
//                 {
//                     Console.Write(box + " ");
//                 }
//                 Console.WriteLine();
//             }

            // Q2580 - 스도쿠

            
            // Q14888 - 연산자 끼워넣기


            // Q14889 - 스타트와 링크


        }
    }
}
