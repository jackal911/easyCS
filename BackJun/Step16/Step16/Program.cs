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
				long first = 1;
				long second = 2;
				for (int i = 3; i <= N; i++)
				{
					long temp = (first + second) % 15746;
					first = second;
					second = temp;
				}
				return second;
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
			
			// Q1904 - 01타일
			int N = int.Parse(Console.ReadLine());
			int[] nums = new int[1000001];
			nums[1] = 1;
			nums[2] = 2;
			for (int i = 3; i <= N; i++)
			{
				nums[i] = (nums[i-1] + nums[i-2]) % 15746;
			}
			Console.WriteLine(nums[N]);
			
			// Q9461 - 파도반 수열
			int T = int.Parse(Console.ReadLine());
			long[] P = new long[101];
			P[1] = 1;
			P[2] = 1;
			P[3] = 1;
			int idx = 4;
			for (int i = 0; i < T; i++)
			{
				int N = int.Parse(Console.ReadLine());
				while (idx <= N)
				{
					P[idx] = P[idx - 3] + P[idx - 2];
					idx++;
				}
				Console.WriteLine(P[N]);
			}
			
			// Q1912 - 연속합
			Console.ReadLine();
			int[] integers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int max = -1001;
			int sum = 0;
			foreach (int integer in integers)
			{
				sum += integer;
				if (sum > max)
				{
					max = sum;
				}
				if (sum < 0)
				{
					sum = 0;
				}
			}
			Console.WriteLine(max);
			
			// Q1149 - RGB거리
			int N = int.Parse(Console.ReadLine());
			List<List<int>> inpStreet = new List<List<int>>();
			for (int i = 0; i < N; i++)
			{
				inpStreet.Add(Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList());
			}
			for (int i = 1; i < N; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int house1 = (j + 2) % 3;
					int house2 = (j + 1) % 3;
					inpStreet[i][j] += Math.Min(inpStreet[i - 1][house1], inpStreet[i - 1][house2]);
				}
			}
			Console.WriteLine(inpStreet[N - 1].Min());
			
			// Q1932 - 정수 삼각형
			int n = int.Parse(Console.ReadLine());
			int[][] triNums = new int[n][];
			for (int i = 0; i < n; i++)
			{
				triNums[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			}
			for (int i = 1; i < n; i++)
			{
				int length = triNums[i].Length;
				// 첫점과 끝점 사전 작업
				triNums[i][0] += triNums[i - 1][0];
				triNums[i][length - 1] += triNums[i - 1][length - 2];
				for (int j = 1; j < length - 1; j++)
				{
					triNums[i][j] += Math.Max(triNums[i - 1][j], triNums[i - 1][j - 1]);
				}
			}
			Console.WriteLine(triNums[n - 1].Max());
			
			// Q2579 - 계단 오르기
			int N = int.Parse(Console.ReadLine());
			int[][] floor = new int[N][];
			for (int i = 0; i < N; i++)
			{
				floor[i] = new int[2] { int.Parse(Console.ReadLine()), 0 };
			}
			if (N > 1)
			{
				floor[1][1] = floor[0][0] + floor[1][0];
				for (int i = 2; i < N; i++)
				{
					floor[i][1] = floor[i][0] + floor[i - 1][0];
					floor[i][0] += Math.Max(floor[i - 2][0], floor[i - 2][1]);
				}
			}
			Console.WriteLine(floor[N-1].Max());
			
			// Q1463 - 1로 만들기
			int N = int.Parse(Console.ReadLine());
			int[] counts = new int[N + 1];
			counts[1] = 0;
			for (int i = 2; i <= N; i++)
			{
				int minCount = counts[i - 1];
				if (i % 3 == 0 && counts[i / 3] < minCount)
				{
					minCount = counts[i / 3];
				}
				if (i % 2 == 0 && counts[i / 2] < minCount)
				{
					minCount = counts[i / 2];
				}
				counts[i] = minCount + 1;
			}
			Console.WriteLine(counts[N]);
			
			// Q10844 - 쉬운 계단 수
			int N = int.Parse(Console.ReadLine());
			int[] numCount = new int[10] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
			int i = 1;
			while (i < N)
			{
				int[] tempCount = new int[10];
				tempCount[0] = numCount[1];
				tempCount[9] = numCount[8];
				for (int j = 1; j < 9; j++)
				{
					tempCount[j] = (numCount[j - 1] + numCount[j + 1])%1000000000;
				}
				numCount = tempCount.ToArray();
				i++;
			}
			int sum = 0;
			foreach (int count in numCount)
			{
				sum += count;
				sum %= 1000000000;
			}
			Console.WriteLine(sum);
			
			// Q2156 - 포도주 시식
			int n = int.Parse(Console.ReadLine());
			int[] grapeAlcohol = new int[n+1];
			for (int i = 1; i <= n; i++)
			{
				grapeAlcohol[i] = int.Parse(Console.ReadLine());
			}
			int[] dp = new int[n + 1];
			dp[1] = grapeAlcohol[1];
			if (n > 1)
			{
				dp[2] = grapeAlcohol[1] + grapeAlcohol[2];
			}
			for (int i = 3; i <= n; i++)
			{
				dp[i] = Math.Max(Math.Max(dp[i - 1], dp[i - 3] + grapeAlcohol[i - 1] + grapeAlcohol[i]), dp[i - 2] + grapeAlcohol[i]);
			}
			Console.WriteLine(dp[n]);
			
			// Q11053 - 가장 긴 증가하는 부분 수열
			int N = int.Parse(Console.ReadLine());
			int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			Dictionary<int, int> dp = new Dictionary<int, int>();
			for (int i = 0; i < N; i++)
			{
				bool gotThis = dp.ContainsKey(sequence[i]);
				bool gotSmallerThings = dp.Keys.Any(s => s < sequence[i]);
				if (gotThis == false)
				{
					if (gotSmallerThings == true)
					{
						dp[sequence[i]] = dp.Where(s => s.Key < sequence[i]).OrderBy(s=>s.Value).Last().Value + 1;
					}
					else
					{
						dp[sequence[i]] = 1;
					}
				}
				else
				{
					if (gotSmallerThings == true)
					{
						dp[sequence[i]] = Math.Max(dp[sequence[i]], dp.Where(s => s.Key < sequence[i]).OrderBy(s => s.Value).Last().Value + 1);
					}
				}
			}
			Console.WriteLine(dp.Values.Max());
			
			// Q11054 - 가장 긴 바이토닉 부분 수열
			int N = int.Parse(Console.ReadLine());
			int[] inpArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] fromZeroDp = new int[N];
			int[] fromEndDp = new int[N];
			for (int i = 0; i < N; i++)
			{
				int count = 0;
				for (int j = 0; j < i; j++)
				{
					if (inpArr[i] > inpArr[j])
					{
						count = Math.Max(fromZeroDp[j], count);
					}
				}
				fromZeroDp[i] = count + 1;
			}
			for (int i = N-1; i >=0; i--)
			{
				int count = 0;
				for (int j = N-1; j > i; j--)
				{
					if (inpArr[i] > inpArr[j])
					{
						count = Math.Max(fromEndDp[j], count);
					}
				}
				fromEndDp[i] = count + 1;
			}
			int maxBitonic = 0;
			for (int i = 0; i < N; i++)
			{
				maxBitonic = Math.Max(fromEndDp[i] + fromZeroDp[i], maxBitonic);
			}
			Console.WriteLine(maxBitonic - 1);
			
			// Q2565 - 전깃줄
			int N = int.Parse(Console.ReadLine());
			List<Tuple<int, int>> lines = new List<Tuple<int, int>>();
			for (int i = 0; i < N; i++)
			{
				int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
				lines.Add(new Tuple<int, int>(line[0], line[1]));
			}
			lines = lines.OrderBy(s => s.Item1).ToList();
			int[] placeB = lines.Select(s => s.Item2).ToArray();
			int[] LIS = new int[N];
			for (int i = 0; i < N; i++)
			{
				int count = 0;
				for (int j = 0; j <= i; j++)
				{
					if (placeB[i] > placeB[j])
					{
						count = Math.Max(count, LIS[j]);
					}
				}
				LIS[i] = count + 1;
			}
			Console.WriteLine(N - LIS.Max());
			*/
			// 1차 시도 - 실패
// 			int N = int.Parse(Console.ReadLine());
// 			Dictionary<string, List<string>> noNeedDp = new Dictionary<string, List<string>>();
// 			for (int i = 0; i < N; i++)
// 			{
// 				string newElectronicLine = Console.ReadLine();
// 				noNeedDp[newElectronicLine] = new List<string>();
// 				int[] newLineIndex = Array.ConvertAll(newElectronicLine.Split(), int.Parse);
// 				for (int j = 0; j < noNeedDp.Count; j++)
// 				{
// 					string jthLine = noNeedDp.ElementAt(j).Key;
// 					int[] jthLineIndex = Array.ConvertAll(jthLine.Split(), int.Parse);
// 					if ((newLineIndex[0] - jthLineIndex[0]) * (newLineIndex[1] - jthLineIndex[1]) < 0) // 엇갈렸으면
// 					{
// 						noNeedDp[newElectronicLine].Add(jthLine); // 새 전기줄에 겹치는 줄 추가
// 						noNeedDp[jthLine].Add(newElectronicLine); // 겹치는 줄에 새 전기줄 추가
// 					}
// 				}
// 			}
// 
// 			int removeCount = 0;
// 			while (noNeedDp.Keys.Any(s => noNeedDp[s].Count > 0))
// 			{
// 				int maxCount = noNeedDp.Max(s => s.Value.Count);
// 				IEnumerable<KeyValuePair<string, List<string>>> a = noNeedDp.Where(s => s.Value.Count == maxCount);
// 				string lineToRemove = noNeedDp.Where(s => s.Value.Count == maxCount).First().Key;
// 				foreach (string lines in noNeedDp[lineToRemove])
// 				{
// 					noNeedDp[lines].Remove(lineToRemove); // 연결된놈에서 삭제할놈 삭제
// 				}
// 				noNeedDp[lineToRemove] = new List<string>(); // 삭제할놈이 가진 리스트 초기화
// 				removeCount++;
// 			}
// 			Console.WriteLine(removeCount);

			// Q9251 - LCS
			string str1 = Console.ReadLine();
			string str2 = Console.ReadLine();
			int LCSlength = str2.Length;
			int[] LCS = new int[LCSlength];
			int startIdx = -1;
			for (int i = 0; i < LCSlength; i++)
			{
				char startChar = str2[i];
				for (int j = i + 1; j < str1.Length; j++)
				{

				}
			}

			// Q12865 - 평범한 배낭
		}
	}
}
