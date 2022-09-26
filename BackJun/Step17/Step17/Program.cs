using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
			*/
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
			string S = Console.ReadLine();
			List<int[]> savePartialSum = new List<int[]>();
			foreach (char ch in S)
			{

			}
			int q = int.Parse(Console.ReadLine());

			// Q10986 - 나머지 합 https://www.acmicpc.net/problem/10986


			// Q11660 - 구간 합 구하기 5 https://www.acmicpc.net/problem/11660
		}
	}
}
