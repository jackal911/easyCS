using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextBigNumber
{
	// 다음 큰 숫자 - https://school.programmers.co.kr/learn/courses/30/lessons/12911
	class Program
	{
		private class Solution
		{
			public int solution(int n)
			{
				int binaryOneCount = Convert.ToString(n, 2).Count(s => s == '1');
				for (int i = n + 1; ; i++)
				{
					if (Convert.ToString(i, 2).Count(s => s == '1') == binaryOneCount)
					{
						return i;
					}
				}
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution(1000000));
		}
	}
}
