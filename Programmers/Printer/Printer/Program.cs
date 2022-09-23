using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Printer
{
	class Program
	{
		public class Solution
		{
			public int solution(int[] priorities, int location)
			{
				int target = priorities[location];
				int printCount;
				if (priorities.Count(s => s == target) == 1)
				{
					printCount = priorities.Count(s => s > target) + 1;
				}
				else
				{
					List<int> listIsCozy = priorities.ToList();
					printCount = 0;
					while (true)
					{
						int head = listIsCozy.First();						
						if (head == listIsCozy.Max())
						{
							printCount++;
							if (location == 0)
							{
								break;
							}
						}
						else
						{
							listIsCozy.Add(head);
						}
						listIsCozy.RemoveAt(0);
						location = location == 0 ? listIsCozy.Count - 1 : location - 1;
					}
				}
				return printCount;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			int[] priorities = { 1, 1, 9, 1, 1, 1 };
			Console.WriteLine(s.solution(priorities, 0));
		}
	}
}
