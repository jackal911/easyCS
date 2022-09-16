using System;
using System.Collections.Generic;
using System.Linq;

namespace N_Lcm
{
	// N개의 최소공배수 - https://school.programmers.co.kr/learn/courses/30/lessons/12953
	class Program
	{
		public class Solution
		{
			public int solution(int[] arr)
			{
				int factor = 2;
				int lcm = 1;
				while (arr.Any(s=>s!=1))
				{
					if (arr.Count(s => s % factor == 0) > 0)
					{
						arr = arr.Select(s => s % factor == 0 ? s / factor : s).ToArray();
						lcm *= factor;
					}
					else
					{
						factor++;
					}
				}
				return lcm;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] arr = { 1, 6, 6, 14 };
			Console.WriteLine(s.solution(arr));
		}
	}
}
