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
		// Q2580 - 스도쿠
		static List<List<int>> board = new List<List<int>>(9);
		static List<List<int>> point = new List<List<int>>(81);
		static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		//static Stopwatch stopwatch = new Stopwatch();

		// Q14888 - 연산자 끼워넣기
		class InsertOperators
		{
			public int min;
			public int max;
			public InsertOperators()
			{
				min = 1000000000;
				max = -1000000000;
			}

			public void getMinMax(List<int> nums, List<int> operators)
			{
				int startNum = nums[0];
				if (nums.Count > 1)
				{
					for (int i = 0; i < 4; i++)
					{
						if (operators[i] > 0)
						{
							List<int> copyNums = nums.GetRange(1, nums.Count - 1);
							List<int> copyOperators = operators.ToList();
							copyNums[0] = getOperateResult(startNum, copyNums[0], i);
							copyOperators[i]--;
							getMinMax(copyNums, copyOperators);
						}
					}
				}
				else
				{
					if (startNum > max)
					{
						max = startNum;
					}
					if (startNum < min)
					{
						min = startNum;
					}
				}
			}

			private int getOperateResult(int startNum, int secondNum, int oper)
			{
				switch (oper)
				{
					case 0:
						return startNum + secondNum;
					case 1:
						return startNum - secondNum;
					case 2:
						return startNum * secondNum;
					default:
						return startNum / secondNum;
				}
			}

		}

        // Q14889 - 스타트와 링크
		class StartAndLink
		{
			public int min = 2000;
			void solution()
			{
				int N = int.Parse(Console.ReadLine());
				List<List<int>> ability = new List<List<int>>(N);
				Dictionary<string, int> colabor = new Dictionary<string, int>();
				for (int i = 0; i < N; i++)
				{
					ability.Add(Console.ReadLine().Split().ToList().ConvertAll(int.Parse));
				}
				for (int i = 0; i < N - 1; i++)
				{
					for (int j = i + 1; j < N; j++)
					{
						colabor[i + "" + j] = ability[i][j] + ability[j][i];
					}
				}
				int totalScore = colabor.Values.Sum();
			}
		}

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
		//기본 스도쿠 규칙을 만족하는지 확인한다.
		static bool check(int y, int x, int num)
		{
			//x,y축에 동일한 수가 존재하는지 확인
			for (int i = 0; i < 9; i++)
			{
				if (board[y][i] == num)
					return false;
				else if (board[i][x] == num)
					return false;
			}
			//3*3칸에 동일한 수가 존재하는지 확인
			for (int i = (y / 3) * 3; i < (y / 3) * 3 + 3; i++)
			{
				for (int j = (x / 3) * 3; j < (x / 3) * 3 + 3; j++)
				{
					if (board[i][j] == num)
						return false;
				}
			}
			//동일한 수가 없으면 true를 반환
			return true;
		}

		//스도쿠에 아직 발견되지 않은 수의 개수만큼 재귀법을 활용해 해결하도록 하였다.
		static void solve_sudoku(int N)
		{
			//만일 N에 도달할 하였다면, 모든 조건을 만족시키는 해답이다.
			//즉, 출력을 하고 함수를 종료한다.
			if (N == point.Count)
			{
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						sw.Write(board[i][j] + " ");
					}
					sw.WriteLine();
				}
				sw.Close();
				//stopwatch.Stop();
				//Console.WriteLine(stopwatch.ElapsedMilliseconds);
				Environment.Exit(0);
			}
			else
			{
				//이번 수의 y,x좌표를 vector에서 가져온다.
				int y = point[N][0];
				int x = point[N][1];
				//1~9까지 모든 수를 넣어본다.
				for (int num = 1; num <= 9; num++)
				{
					//조건을 만족하는지 확인
					if (check(y, x, num))
					{
						//조건을 만족하면 수를 넣고
						board[y][x] = num;
						//재귀함수를 호출한다.
						solve_sudoku(N + 1);
						//이후 함수가 종료된 이후에는 0으로 초기화를 해준다.
						board[y][x] = 0;
					}
				}
			}
		}

		// Q14888 - 연산자 끼워넣기
		

		// Q14889 - 스타트와 링크

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
			
			// Q2580 - 스도쿠
			for (int i = 0; i < 9; i++)
			{
				string input = Console.ReadLine().Replace(" ", "");
				board.Add(input.ToList().ConvertAll(s => (int)s - 48));
				for (int j = 0; j < 9; j++)
				{
					if (input[j] == '0')
					{
						point.Add(new List<int>() { i, j });
					}
				}
			}
			//stopwatch.Start();
			solve_sudoku(0);
            
			// Q14888 - 연산자 끼워넣기
			InsertOperators inOp = new InsertOperators();

			Console.ReadLine();
			List<int> nums = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);
			List<int> operators = Console.ReadLine().Split().ToList().ConvertAll(int.Parse);

			inOp.getMinMax(nums, operators);
			Console.WriteLine("{0}\n{1}", inOp.max, inOp.min);
			*/
			// Q14889 - 스타트와 링크
			StartAndLink sal = new StartAndLink();
			solution();
        }		
    }
}
