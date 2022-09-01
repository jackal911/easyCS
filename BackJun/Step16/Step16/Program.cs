using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step16
{
	// Step16 - 동적 계획법 1 https://www.acmicpc.net/step/16
	class Program
	{
		// Q9184 - 신나는 함수 실행
		class FunctionPlay
		{
			private Dictionary<string, int> saves = new Dictionary<string, int>();
			public int w(int a, int b, int c)
			{
				string key = a + " " + b + " " + c;
				if (saves.ContainsKey(key))
				{
					return saves[key];
				}

				if (a <= 0 || b <= 0 || c <= 0)
				{					
					return 1;
				}
				else if (a > 20 || b > 20 || c > 20)
				{
					return w(20, 20, 20);
				}
				else if (a < b && b < c)
				{
					string key1 = a + " " + b + " " + (c - 1);
					string key2 = a + " " + (b - 1) + " " + (c - 1);
					string key3 = a + " " + (b - 1) + " " + c;
					int result1, result2, result3;

					if (saves.Keys.Contains(key1) == false)
					{
						saves[key1] = w(a, b, c - 1);
					}
					result1 = saves[key1];
					if (saves.Keys.Contains(key2) == false)
					{
						saves[key2] = w(a, b - 1, c - 1);
					}
					result2 = saves[key2];
					if (saves.Keys.Contains(key3) == false)
					{
						saves[key3] = w(a, b - 1, c);
					}
					result3 = saves[key3];

					return result1 + result2 - result3;
				}
				else
				{
					string key1 = (a - 1) + " " + b + " " + c;
					string key2 = (a - 1) + " " + (b - 1) + " " + c;
					string key3 = (a - 1) + " " + b + " " + (c - 1);
					string key4 = (a - 1) + " " + (b - 1) + " " + (c - 1);
					int result1, result2, result3, result4;

					if (saves.Keys.Contains(key1) == false)
					{
						saves[key1] = w(a - 1, b, c);
					}
					result1 = saves[key1];
					if (saves.Keys.Contains(key2) == false)
					{
						saves[key2] = w(a - 1, b - 1, c);
					}
					result2 = saves[key2];
					if (saves.Keys.Contains(key3) == false)
					{
						saves[key3] = w(a - 1, b, c - 1);
					}
					result3 = saves[key3];
					if (saves.Keys.Contains(key4) == false)
					{
						saves[key4] = w(a - 1, b - 1, c - 1);
					}
					result4 = saves[key4];

					return result1 + result2 + result3 - result4;
				}
			}
		}

		// Q1904 - 01타일
		class ZeroOneTile
		{
			public long solution(int N)
			{
				long sum = 0;
				if (N % 2 == 0)
				{
					for (int i = 0; i <= N/2; i++)
					{
						sum += combination(N / 2 + i, N / 2 - i);
						sum %= 15746;
					}
				}
				else
				{
					for (int i = 0; i <= N / 2; i++)
					{
						sum += combination((N + 1) / 2 + i, N / 2 - i);
						sum %= 15746;
					}
				}
				return sum;
			}
			private long combination(long m, long n)
			{
				if (m < n)
				{
					return 0;
				}
				long com = 1;
				for (long i = 0; i < n; i++)
				{
					com *= m--;
					com /= i + 1;
				}
				return com;
			}
		}
		static void Main(string[] args)
		{
			/*
			// Q24416 - 알고리즘 수업 - 피보나치 수 1
			int n = int.Parse(Console.ReadLine());
			int temp = 0;
			int first = 1;
			int second = 1;
			for (int i = 3; i <= n; i++)
			{
				temp = second;
				second = first + second;
				first = temp;
			}
			Console.WriteLine("{0} {1}", second, n - 2);
			
			// Q9184 - 신나는 함수 실행
			FunctionPlay fp = new FunctionPlay();
			int[] inp;
			while((inp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse)).Any(s=>s!=-1)){
				Console.WriteLine("w({0}, {1}, {2}) = {3}", inp[0], inp[1], inp[2], fp.w(inp[0], inp[1], inp[2]));
			}
			*/
			// Q1904 - 01타일
			ZeroOneTile zot = new ZeroOneTile();
			int N = int.Parse(Console.ReadLine());
			Console.WriteLine(zot.solution(N));

			// Q9461 - 파도반 수열


			// Q1912 - 연속합


			// Q1149 - RGB거리


			// Q1932 - 정수 삼각형


			// Q2579 - 계단 오르기

			
			// Q1463 - 1로 만들기


			// Q10844 - 쉬운 계단 수


			// Q2156 - 포도주 시식


			// Q11053 - 가장 긴 증가하는 부분 수열


			// Q11054 - 가장 긴 바이토닉 부분 수열


			// Q2565 - 전깃줄


			// Q9251 - LCS


			// Q12865 - 평범한 배낭
		}
	}
}
