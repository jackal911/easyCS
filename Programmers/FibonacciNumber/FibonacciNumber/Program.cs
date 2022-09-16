using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibonacciNumber
{
	// 피보나치 수 - https://school.programmers.co.kr/learn/courses/30/lessons/12945
	class Program
	{
		public class Solution
		{
			public int solution(int n)
			{
				List<int> fibo = new List<int>() { 0, 1 };
				for (int i = 2; i <= n; i++)
				{
					fibo.Add((fibo[i - 1] + fibo[i - 2])%1234567);
				}
				return fibo[n];
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution(100000));
		}
	}
}
