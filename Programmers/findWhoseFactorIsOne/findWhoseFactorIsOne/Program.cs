using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace findWhoseFactorIsOne
{
	class Program
	{
		public class Solution
		{
			public int solution(int n)
			{
				for (int i = 2; i <= Math.Sqrt(n); i++)
				{
					if ((n - 1) % i == 0)
					{
						return i;
					}
				}
				return n - 1;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution(999998));
		}
	}
}
