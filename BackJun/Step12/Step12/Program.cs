using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Step12 - 집합과 맵 https://www.acmicpc.net/step/49

namespace Step12
{

    class Program
    {
        // Q10815 - 숫자 카드
        // 바이너리 서치
        static int binarySearch(int toFind, int[] where)
        {
            int left = 0;
            int right = where.Length - 1;
            while (left < right)
            {
                int mid = (right + left) / 2;
                if (where[left] == toFind || where[mid] == toFind)
                    return 1;
                if (where[mid] < toFind)
                    left = mid + 1;
                else
                    right = mid;
            }
            return where[right] == toFind ? 1 : 0;
        }
        static void Main(string[] args)
        {
            /*
            // Q10815 - 숫자 카드 https://www.acmicpc.net/problem/10815
            // 바이너리 서치 - 시간 초과
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine(); // 노필요
            int[] card = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Array.Sort(card);
            sr.ReadLine(); // 노필요
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            foreach (var num in nums)
            {
                sw.Write("{0} ", binarySearch(num, card));
            }
            sw.Close();
            
            // 카운트 소팅
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine(); // 노필요
            int[] card = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Array.Sort(card);
            sr.ReadLine(); // 노필요
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            bool[] yesOrNo = new bool[20000001];
            foreach (var num in card)
                yesOrNo[num + 10000000] = true;
            foreach (var num in nums)
            {
                sw.Write("{0} ", yesOrNo[num + 10000000] ? 1 : 0);
            }
            sw.Close();
            
<<<<<<< HEAD
            // Q14425 - 문자열 집합
            // 푼 사람이 없다. - 시간 초과 실패(22.7.13)
            // dictionary 쓰니까 그냥 깸/
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int[] NM = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Dictionary<string, bool> strSet = new Dictionary<string, bool>();
            int count = 0;
            for (int i = 0; i < NM[0]; i++)
            {
                strSet[sr.ReadLine()] = true;
            }
            for (int j = 0; j < NM[1]; j++)
            {
=======
<<<<<<< HEAD
            // Q14425 - 문자열 집합 https://www.acmicpc.net/problem/14425
            // 푼 사람이 없다. - 실패(22.7.13)
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int[] NM = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            List<string> strSet = new List<string>();
            int count = 0;
            for (int i = 0; i < NM[0]; i++)
            {
                strSet.Add(sr.ReadLine());
            }
            for (int j = 0; j < NM[1]; j++)
            {
                if (strSet.Contains(sr.ReadLine()))
                    count++;
            }
            sr.Close();
            sw.WriteLine(count);
            sw.Close();
            
            // Q1620 - 나는야 포켓몬 마스터 이다솜 https://www.acmicpc.net/problem/1620
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int[] NM = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Dictionary<string, string> illustratedBook = new Dictionary<string, string>();
            for (int i = 1; i <= NM[0]; i++)
            {
                string inp = sr.ReadLine();
                illustratedBook[i.ToString()] = inp;
                illustratedBook[inp] = i.ToString();
            }
            for (int j = 0; j < NM[1]; j++)
            {
                sw.WriteLine(illustratedBook[sr.ReadLine()]);
            }
            sr.Close();
            sw.Close();
            
            // Q10816 - 숫자 카드 2 https://www.acmicpc.net/problem/10816
            // 이것저것 테스트겸 써봤지만 시간초과
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            
            Dictionary<string, int> cardsDict = new Dictionary<string, int>();
            sr.ReadLine();
            foreach (string cardNum in sr.ReadLine().Split())
            {
                int value = 1;
                cardsDict.TryGetValue(cardNum, out value);
                cardsDict[cardNum] = ++value;                
            }
            sr.ReadLine();
            foreach (string questionNum in sr.ReadLine().Split())
            {
                sw.Write(cardsDict.SingleOrDefault(kv => kv.Key == questionNum).Value + " ");
            }
            sr.Close();
            sw.Close();
            
            // 아슬아슬하게 정답. 1초 컷인데 960ms.
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            
            Dictionary<string, int> cardsDict = new Dictionary<string, int>();
            sr.ReadLine();
            foreach (string card in sr.ReadLine().Split())
            {
                if (cardsDict.ContainsKey(card))
                {
                    cardsDict[card]++;
                }
                else
                {
                    cardsDict[card] = 1;
                }

            }
            sr.ReadLine();
            foreach (string questionNum in sr.ReadLine().Split())
            {
                if (cardsDict.ContainsKey(questionNum))
                {
                    sw.Write(cardsDict[questionNum] + " ");
                }
                else
                {
                    sw.Write(0 + " ");
                }

            }
            sr.Close();
            sw.Close();
            
            // Q1764 - 듣보잡 https://www.acmicpc.net/problem/1764
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            List<int> NM = sr.ReadLine().Split().Select(s => int.Parse(s)).ToList();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int value;
            for (int i = 0; i < NM.Sum(); i++)
            {                
                string inp = sr.ReadLine();
                dict.TryGetValue(inp, out value);
                dict[inp] = ++value;
            }
            sr.Close();
            var dbjob = dict.Where(s => s.Value > 1);
            sw.WriteLine(dbjob.Count());
            dbjob.Select(s => s.Key).OrderBy(s=>s).ToList().ForEach(s => sw.WriteLine(s));
            sw.Close();
            
            // Q1267 - 대칭 차집합 https://www.acmicpc.net/problem/1269
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sr.ReadLine();
            HashSet<int> allNums = new HashSet<int>(sr.ReadLine().Split().Select(s => int.Parse(s)));
            HashSet<int> commonNums = new HashSet<int>(sr.ReadLine().Split().Select(s => int.Parse(s)));
            sr.Close();
            allNums.SymmetricExceptWith(commonNums);
            sw.WriteLine(allNums.Count);
            sw.Close();
            */
            // Q11478 - 서로 다른 부분 문자열의 개수 https://www.acmicpc.net/problem/11478
            string inp = Console.ReadLine();
            HashSet<string> strs = new HashSet<string>();
            for (int i = 1; i <= inp.Length; i++)
            {
                for (int j = 0; j <= inp.Length - i;j++ )
                {
                    strs.Add(inp.Substring(j, i));
                }
            }
            Console.WriteLine(strs.Count);
=======
            // Q14425 - 문자열 집합
            // 푼 사람이 없다. - 시간 초과 실패(22.7.13)
            // dictionary 쓰니까 그냥 깸/
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            int[] NM = Array.ConvertAll(sr.ReadLine().Split(), Int32.Parse);
            Dictionary<string, bool> strSet = new Dictionary<string, bool>();
            int count = 0;
            for (int i = 0; i < NM[0]; i++)
            {
                strSet[sr.ReadLine()] = true;
            }
            for (int j = 0; j < NM[1]; j++)
            {
>>>>>>> local
                if (strSet.ContainsKey(sr.ReadLine()))
                    count++;
            }
            sw.WriteLine(count);
            sw.Close();
            */
            // Q1620 - 나는야 포켓몬 마스터 이다솜

<<<<<<< HEAD
=======
>>>>>>> origin/main
>>>>>>> local
        }
    }
}
