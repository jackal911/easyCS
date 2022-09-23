using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camouflage
{
	class Program
	{
		public class Solution
		{
			public int solution(string[,] clothes)
			{
				int caseCount = 1;
				Dictionary<string, List<string>> clothesSort = new Dictionary<string, List<string>>();
				int firstLength = clothes.GetLength(0);
				for (int i = 0; i < firstLength; i++)
				{
					if (clothesSort.ContainsKey(clothes[i, 1]) == false)
					{
						clothesSort[clothes[i, 1]] = new List<string>();
					}
					clothesSort[clothes[i, 1]].Add(clothes[i, 0]);
				}
				
				foreach (var kv in clothesSort)
				{
					caseCount *= (kv.Value.Count + 1);
				}
				return caseCount - 1;
			}
		}
		static void Main(string[] args)
		{
		}
	}
}
