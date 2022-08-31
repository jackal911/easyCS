using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KindOfMBTI
{
	class Program
	{
		public class Solution
		{
			public string solution(string[] survey, int[] choices)
			{
				string answer = "";
				Dictionary<string, int> mbti = new Dictionary<string, int>();
				mbti["RT"] = 0;
				mbti["CF"] = 0;
				mbti["JM"] = 0;
				mbti["AN"] = 0;
				for (int i = 0; i < survey.Length; i++)
				{
					if (survey[i][0] > survey[i][1])
					{
						survey[i] = survey[i][1] + "" + survey[i][0];
						choices[i] = 4 * 2 - choices[i];
					}
					mbti[survey[i]] += choices[i] - 4;
				}

				foreach (var kv in mbti)
				{
					if (kv.Value <= 0)
					{
						answer += kv.Key[0];
					}
					else
					{
						answer += kv.Key[1];
					}
				}

				return answer;
			}
		}
		static void Main(string[] args)
		{
			Solution s = new Solution();
			string[] survey = new string[] { "TR", "RT", "TR" };
			int[] choices = new int[] { 7, 1, 3 };
			Console.WriteLine(s.solution(survey, choices));
		}
	}
}
