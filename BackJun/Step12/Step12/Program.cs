using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
            // Q10815 - 숫자 카드
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
                if (strSet.ContainsKey(sr.ReadLine()))
                    count++;
            }
            sw.WriteLine(count);
            sw.Close();
            */
            // Q1620 - 나는야 포켓몬 마스터 이다솜

        }
    }
}
