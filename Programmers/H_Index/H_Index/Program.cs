using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H_Index
{
	class Program
	{
		public class Solution
		{
			public int solution(int[] citations)
			{
				int n = 1;
				while (n++ <= 1000)
				{
					if (citations.Where(s => s >= n).Count() < n)
					{
						break;
					}
				}
				return n-1;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] citations = { 3, 0, 6, 1, 5 };
			Console.WriteLine(s.solution(citations));
		}
	}
}
