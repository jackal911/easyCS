using System;
using System.Collections.Generic;
using System.Linq;

namespace DoublePriorQueue
{
	class Program
	{
		public class Solution
		{
			public int[] solution(string[] operations)
			{
				List<int> queue = new List<int>();
				foreach (string op in operations)
				{
					if (op.StartsWith("I"))
					{
						queue.Add(int.Parse(op.Substring(2)));
					}
					else
					{
						if (queue.Count > 0)
						{
							if (op[2] == '-')
							{
								queue.Remove(queue.Min());
							}
							else
							{
								queue.Remove(queue.Max());
							}
						}
					}
				}
				return queue.Count == 0 ? new int[2] { 0, 0 } : new int[2] { queue.Max(), queue.Min() };
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			string[] operations = { "I -45", "I 653", "D 1", "I -642", "I 45", "I 97", "D 1", "D -1", "I 333" };
			int[] result = s.solution(operations);
			Console.WriteLine("{0} {1}", result[0], result[1]);
		}
	}
}
