using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Step7 - 기본 수학 1 https://www.acmicpc.net/step/8

namespace Step7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Q1712 - 손익분기점
            List<double> inp = Console.ReadLine().Split().ToList().ConvertAll(s => double.Parse(s));
            int result = inp[1] >= inp[2] ? -1 : inp[0] % (inp[2] - inp[1]) == 0 ? (int)(inp[0] / (inp[2] - inp[1])+1) : (int)Math.Ceiling(inp[0] / (inp[2] - inp[1]));
            Console.WriteLine(result);
            
            // Q2292 - 벌집
            int N = int.Parse(Console.ReadLine());
            int i=1;
            bool end = false;
            while (!end)
            {
                if (N <= 3 * i * (i - 1) + 1)
                {
                    end = true;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(i);
            
            // Q1193 - 분수찾기
            int X = int.Parse(Console.ReadLine());
            int i = 1;
            string result = "";            
            while(true){
                if(X<=i*(i+1)/2){
                    X = i*(i+1)/2 - X;
                    if(i%2==0)
                        result = String.Format("{0}/{1}", i-X, 1+X);
                    else
                        result = String.Format("{0}/{1}", 1+X, i-X);
                    break;
                }
                i++;
            }
            Console.WriteLine(result);
            
            // Q2869 - 달팽이는 올라가고 싶다
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result = (nums[2] - nums[0]) % (nums[0] - nums[1]) == 0 ? (nums[2] - nums[0]) / (nums[0] - nums[1]) + 1 : (nums[2] - nums[0]) / (nums[0] - nums[1]) + 2;
            Console.WriteLine(result);
            
            // Q10250 - ACM 호텔
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int[] H = Enumerable.Range(0, nums[0]).ToArray();
                H[0] = nums[0];
                Console.WriteLine("{0}{1:00}", H[nums[2] % nums[0]], (int)Math.Ceiling((double)nums[2] / nums[0]));
            }
            
            // Q2775 부녀회장이 될테야
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int k = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                List<int> people = Enumerable.Range(0, n + 1).ToList();
                for (int j = 1; j <= k; j++)
                {
                    for (int l = n; l >= 1;l-- )
                    {
                        people[l] = Enumerable.Sum(people.GetRange(0, l+1));                     
                    }
                }
                Console.WriteLine(people[n]);
            }
            
            // Q2839 - 설탕 배달
            int N = int.Parse(Console.ReadLine());            
            int result = -1;
            int fiveBonjiCount = N/5;
            while (fiveBonjiCount>=0)
            {
                if ((N - 5 * fiveBonjiCount) % 3 == 0)
                {
                    result = (N - 5 * fiveBonjiCount) / 3 + fiveBonjiCount;
                    break;
                }
                fiveBonjiCount--;
            }
            Console.WriteLine(result);
            */
            // Q10757 - 큰 수 A+B
            string[] nums = Console.ReadLine().Split();
            int maxIndex = nums[0].Length>nums[1].Length ? 0 : 1;
            string maxNumR = String.Join("", nums[maxIndex].Reverse());
            string minNumR = String.Join("", nums[1-maxIndex].Reverse());
            string result = "";
            int up=0;
            for (int i = 0; i < maxNumR.Length; i++)
            {                
                int curNum;
                if (i < minNumR.Length)
                {
                    curNum = maxNumR[i] + minNumR[i] - 96 + up;
                    //Console.WriteLine("max : {0}, min : {1}", maxNumR[i] - 48, minNumR[i] - 48);
                }
                else
                {
                    curNum = maxNumR[i] - 48 + up;
                    //Console.WriteLine("max : {0}", maxNumR[i] - 48);
                }

                if (curNum >= 10)
                    up = 1;
                else
                    up = 0;

                result += (curNum % 10).ToString();
            }
            if (up == 1)
                result += "1";
            Console.WriteLine(String.Join("", result.Reverse()));
        }
    }
}
