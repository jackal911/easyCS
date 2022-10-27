using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Step17
{
	// Step17 - 누적 합 https://www.acmicpc.net/step/48
	class Program
	{
		static void Main(string[] args)
		{
			/*
			// Q11659 - 구간 합 구하기 4 https://www.acmicpc.net/problem/11659
			StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
			int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			for (int i = 1; i < NM[0]; i++)
			{
				nums[i] += nums[i - 1];
			}
			int[] ij;
			int sum;
			for (int i = 0; i < NM[1]; i++)
			{
				ij = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
				sum = nums[ij[1] - 1];
				if (ij[0] > 1)
				{
					sum -= nums[ij[0] - 2];
				}
				sw.Write(sum + "\n");
			}
			sw.Close();
			
			// Q2559 - 수열 https://www.acmicpc.net/problem/2559
			int[] NK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] temperatures = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] partialSum = temperatures.ToArray();
			if (NK[1] > 1)
			{
				for (int i = 1; i < NK[0]; i++)
				{
					partialSum[i] += partialSum[i - 1];
					if (i - NK[1] >= 0)
					{
						partialSum[i] -= temperatures[i - NK[1]];
					}
				}
			}
			Console.WriteLine(partialSum.Where((v, i) => i >= NK[1] - 1).Max());
			
			// Q16139 - 인간-컴퓨터 상호작용 https://www.acmicpc.net/problem/16139
			StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
			string S = Console.ReadLine();
			List<int[]> savePartialSum = new List<int[]>();
			int[] alphabetSums = new int[26];
			foreach (char ch in S)
			{
				alphabetSums[(int)ch - 97]++;
				savePartialSum.Add(alphabetSums.ToArray());
			}
			int q = int.Parse(Console.ReadLine());
			string[] question;
			char alphabet;
			int start, end, alphabetSum;
			for (int i = 0; i < q; i++)
			{
				alphabetSum = 0;
				question = Console.ReadLine().Split();
				alphabet = Char.Parse(question[0]);
				start = int.Parse(question[1]);
				end = int.Parse(question[2]);
				alphabetSum += savePartialSum[end][(int)alphabet - 97];
				if (start > 0)
				{
					alphabetSum -= savePartialSum[start - 1][(int)alphabet - 97];
				}
				sw.Write(alphabetSum + "\n");
			}
			sw.Close();
			
			// Q10986 - 나머지 합 https://www.acmicpc.net/problem/10986
			long[] NM = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
			//int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			long[] nums = Array.ConvertAll(Enumerable.Range(1, 100000).ToArray(), s=>(long)s);
			long[] mods = new long[1000];
			Stopwatch sw = new Stopwatch();
			sw.Start();
			nums[0] %= NM[1];
			mods[nums[0]]++;
			
			for (int i = 1; i < NM[0]; i++)
			{
				nums[i] += nums[i - 1];
				nums[i] %= NM[1];
				mods[nums[i]]++;
			}
			long modMCount = mods[0];
			for (int i = 0; i < NM[1]; i++)
			{
				if (mods[i] > 0)
				{
					modMCount += (long)(mods[i] * (mods[i] - 1)) / 2;
				}
			}
			// Console.WriteLine(String.Join(", ", nums));
			Console.WriteLine(modMCount);
			Console.WriteLine(sw.ElapsedMilliseconds + " ms");
			*/
			// Q11660 - 구간 합 구하기 5 https://www.acmicpc.net/problem/11660
			StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
			int[] NM = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[][] board = new int[NM[0]][];
			for (int i = 0; i < NM[0]; i++)
			{
				int partSum = 0;
				board[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
				for (int j = 0; j < NM[0]; j++)
				{
					partSum += board[i][j];
					board[i][j] = partSum;
				}
			}
			for (int i = 0; i < NM[1]; i++)
			{
				int[] XYs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
				int resultSum = 0;
				for (int j = XYs[0]; j <= XYs[2]; j++)
				{
					resultSum += board[j - 1][XYs[3] - 1];
					if (XYs[1] > 1)
					{
						resultSum -= board[j - 1][XYs[1] - 2];
					}
				}
				sw.WriteLine(resultSum);
			}
			sw.Close();
		}
	}
}
