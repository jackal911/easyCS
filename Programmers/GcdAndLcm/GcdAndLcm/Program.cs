using System;

namespace GcdAndLcm
{
	// 최대공약수와 최소공배수 - https://school.programmers.co.kr/learn/courses/30/lessons/12940
	class Program
	{
		public class Solution
		{
			private static Func<int, int, int> calGcd = (num1, num2) => num1 % num2 == 0 ? num2 : calGcd(num2, num1 % num2);
			public int[] solution(int n, int m)
			{
				int gcd = calGcd(n, m);
				return new int[] { gcd, n * m / gcd };
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] result = s.solution(2, 5);
			Console.WriteLine("[{0},{1}]", result[0], result[1]);
		}
	}
}
