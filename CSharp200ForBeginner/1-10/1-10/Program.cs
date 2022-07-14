using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // 1.
            Console.WriteLine("Hello, World");

            // 2. 
            // 생략

            // 3.
            Console.Write("Hello ");
            Console.WriteLine("World!");
            Console.Write("이름을 입력하세요 : ");

            string name = Console.ReadLine();
            Console.Write("안녕하세요, ");
            Console.Write(name);
            Console.WriteLine("님!");

            // 4.
            

            // 5.


            // 6.


            // 7.


            // 8.


            // 9.

            */
            // 10.
            Console.Clear();

            Console.WriteLine("Standard Numeric Format Specifiers");
            Console.WriteLine(
                "(C) Currency: . . . . . . . . {0:C}\n" +
                "(D) Decimal:. . . . . . . . . {0:D}\n" +
                "(E) Scientific: . . . . . . . {1:E}\n" +
                "(F) Fixed point:. . . . . . . {1:F}\n" +
                "(G) General:. . . . . . . . . {0:G}\n" +
                "(N) Number: . . . . . . . . . {0:N}\n" +
                "(P) Percent:. . . . . . . . . {1:P}\n" +
                "(R) Round-trip: . . . . . . . {1:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n",
                -12345678, -1234.5678f);
        }
    }
}
