using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpAndTeleport
{
	class Program
	{
		class Solution
		{
			public int solution(int n)
			{
				int[] batteryUseData = new int[100000];
				int useCount = 0;
				int startInt = 0;
				while (true)
				{
					startInt++;
					if (batteryUseData[startInt] != 0)
					{
						useCount = batteryUseData[startInt];
						continue;
					}
					useCount++;
					for (int i = startInt; i <= n; i *= 2)
					{
						if (i == n)
						{
							return useCount;
						}
					}
				}
				return batteryUseData[n];
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution(999999999));
		}
	}
}
