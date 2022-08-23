using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Dynamic;

namespace Step15
{
    // Step15 - 백트래킹
    class Program
    {
		// Q2580 - 스도쿠
		static Dictionary<string, dynamic> solution = new Dictionary<string, dynamic>();
		static IEnumerable<int> oneToNine = Enumerable.Range(1, 9);

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
		static bool checkProperPlace(int[] coordinates, int thisRow)
		{
			int thisChess = coordinates[thisRow];
			for (int i = 0; i < thisRow; i++)
			{
				if (coordinates[i] == thisChess || coordinates[i] == thisChess || Math.Abs(i - thisRow) == Math.Abs(coordinates[i] - thisChess))
				{
					return false;
				}
			}
			return true;
		}
		static int NQueen(int[] coordinates, int N, ref int completeCount, int thisRow = 0)
		{
			//int[,] preChessBoard;
			if (thisRow == N)
			{
				return ++completeCount;
			}
			for (int i = 0; i < N; i++)
			{
				coordinates[thisRow] = i;
				if (checkProperPlace(coordinates, thisRow))
				{
					NQueen(coordinates, N, ref completeCount, thisRow + 1);
					if (thisRow == N - 1)
					{
						break;
					}
				}
			}
            //Console.WriteLine();
            return completeCount;
        }

		// Q2580 - 스도쿠
		static string doSudoku(List<List<int>> sudoku)
		{
			string result = "";
			bool isFinished = false;
			while (isFinished == false)
			{
				allCheck(sudoku);
				if (solution.Count == 0)
				{
					isFinished = true;
				}
			}
			return result;
		}

		static void allCheck(List<List<int>> sudoku)
		{
			for (int i = 0; i < 9; i++)
			{
				List<int> row = sudoku[i];
				List<int> column = sudoku.Select(s => s[i]).ToList();
				List<int> rowCheck = oneToNine.ToList();
				List<int> columnCheck = oneToNine.ToList();
				rowCheck = rowCheck.Except(row).ToList();
				columnCheck = columnCheck.Except(column).ToList();
				for (int j = 0; j < 9; j++)
				{
					string key = i + "" + j;
					if (row[j] == 0)
					{
						if (rowCheck.Count == 1)
						{
							if (solution.ContainsKey(key))
							{
								solution.Remove(key);
							}
							sudoku[i][j] = rowCheck[0];
						}
						else
						{
							solution.Add(key, rowCheck);
						}
					}
					if (i != j && column[j] == 0)
					{
						if (columnCheck.Count == 1)
						{
							if (solution.ContainsKey(key))
							{
								solution.Remove(key);
							}
							sudoku[i][j] = columnCheck[0];
						}
						else
						{
							solution.Add(key, columnCheck);
						}
					}
				}
				//Console.WriteLine("row : {0}, column : {1}", row, column);
			}
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
            
			// Q9663 - N-Queen
			int N = int.Parse(Console.ReadLine());
			Stopwatch stopwatch = new Stopwatch(); //객체 선언
			stopwatch.Start(); // 시간측정 시작
			
			int[] coordinates = new int[15];
			int completeCount = 0;
			Console.WriteLine(NQueen(coordinates, N, ref completeCount));

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
			*/
			// Q2580 - 스도쿠
			List<List<int>> sudoku = new List<List<int>>();
			int[] a = new int[9];
			for (int i = 0; i < 9; i++)
			{
				sudoku.Add(Console.ReadLine().Replace(" ", "").ToList().ConvertAll(s=>(int)s-48));
			}
			string b = "abc";

			//doSudoku(sudoku);

			
            
            // Q14888 - 연산자 끼워넣기


            // Q14889 - 스타트와 링크


        }
    }
}
