using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_20
{
    class Program
    {
        static void Main(string[] args)
        {
            float m_speed = 1f;

            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add("speed", m_speed);
            if (dic.TryGetValue("speed", out m_speed))
            {
                m_speed = 2f;
            }
            Console.WriteLine();
        }
    }
}
