using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpinBracket
{
	class Program
	{
		public class Solution
		{
			public int solution(string s)
			{
				int n = 0;
				int count = 0;
				string str;
				List<int> supervisor = new List<int>();
				while (n < s.Length)
				{
					str = s.Substring(n) + s.Substring(0, n);
					supervisor.Clear();
					bool isFailed = false;
					for (int i = 0; i < str.Length; i++)
					{
						switch (str[i])
						{
							case '}':
								if (supervisor.Count == 0 || supervisor.Last() != 1)
								{
									isFailed = true;
								}
								else
								{
									supervisor.RemoveAt(supervisor.Count - 1);
								}
								break;
							case ']':
								if (supervisor.Count == 0 || supervisor.Last() != 2)
								{
									isFailed = true;
								}
								else
								{
									supervisor.RemoveAt(supervisor.Count - 1);
								}
								break;
							case ')':
								if (supervisor.Count == 0 || supervisor.Last() != 3)
								{
									isFailed = true;
								}
								else
								{
									supervisor.RemoveAt(supervisor.Count - 1);
								}
								break;
							case '{':
								supervisor.Add(1);
								break;
							case '[':
								supervisor.Add(2);
								break;
							case '(':
								supervisor.Add(3);
								break;
						}
						if (isFailed == true)
						{
							break;
						}
					}
					if (isFailed == false)
					{
						count++;
					}
					n++;
				}
				return count;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			Console.WriteLine(s.solution("[)(]"));
		}
	}
}
