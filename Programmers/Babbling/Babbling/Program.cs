using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Babbling
{
	// 옹알이 - https://school.programmers.co.kr/learn/courses/30/lessons/120956?language=csharp
	class Program
	{
		static void Main(string[] args)
		{
			string[] babbling = {"ayaye", "uuu", "yeye", "yemawoo", "ayaayaa"};
			var a = babbling.Select(s => s.Replace("ayaaya", "?").Replace("yeye", "?").Replace("woowoo", "?").Replace("mama", "?").Replace("aya", "!").Replace("ye", "!").Replace("woo", "!").Replace("ma", "!").All(ch => ch == '!') ? 1 : 0).Sum();
			
			Console.WriteLine();
		}
	}
}
