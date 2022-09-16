using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EndTalkByEnglish
{
	// 영어 끝말잇기 - https://school.programmers.co.kr/learn/courses/30/lessons/12981
	class Program
	{
		class Solution
		{
			public int[] solution(int n, string[] words)
			{				
				List<string> checkDistinctWord = new List<string>();
				char endAlphabet = words[0][0];
				for (int i = 0; i < words.Length; i++)
				{
					if (endAlphabet != words[i][0] || checkDistinctWord.Contains(words[i]))
					{
						return new int[] { i % n + 1, i / n + 1 };
					}
					checkDistinctWord.Add(words[i]);
					endAlphabet = words[i][words[i].Length - 1];
				}

				return new int[] { 0, 0 };
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			string[] words = { "hello", "one", "even", "never", "now", "world", "draw" };
			int[] result = s.solution(2, words);
			Console.WriteLine("{0}, {1}", result[0], result[1]);
		}
	}
}
