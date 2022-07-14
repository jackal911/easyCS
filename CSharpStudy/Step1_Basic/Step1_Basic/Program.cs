using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Step1_Basic
{
    class Program
    {
        // Main method 이전 객체들 모음
        // 4-1) 변수 예제
        class CSVar
        {
            //필드 (클래스 내에서 공통적으로 사용되는 전역 변수)
            int globalVar;
            const int MAX = 1024;

            public void Method1()
            {
                // 로컬변수
                int localVar;

                // 아래 할당이 없으면 에러 발생
                localVar = 100;

                Console.WriteLine(globalVar);
                Console.WriteLine(localVar);
            }
        }

        class CSVar2
        {
            // 상수
            const int MAX_VALUE = 1024;

            // readonly 필드 
            readonly int Max;
            public CSVar2() // 생성자에서도 초기화 가능
            {
                Max = 1;
            }

            //...
        }

        // 7-1) enum의 사용
        enum City
        {
            Seoul,   // 0
            Daejun,  // 1
            Busan = 5,  // 5
            Jeju = 10   // 10
        }

        // 7-2) 플래그(flag) enum
        enum Border
        {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 4,
            Left = 8
        }

        // 9-3) 조건문 예제
        static bool verbose = false;
        static bool continueOnError = false;
        static bool logging = false;

        // 11-1) yield
        static IEnumerable<int> GetNumber()
        {
            yield return 10;  // 첫번째 루프에서 리턴되는 값
            yield return 20;  // 두번째 루프에서 리턴되는 값
            yield return 30;  // 세번째 루프에서 리턴되는 값
        }

        // 11-2) yield와 Enumerator
        public class MyList
        {
            private int[] data = { 1, 2, 3, 4, 5 };

            public IEnumerator<int> GetEnumerator()
            {
                int i = 0;
                while (i < data.Length)
                {
                    yield return data[i];
                    i++;
                }
            }

            //...
        }

        // 14-1) Value Type vs Reference Type
        // System.Int32 (Value Type)
        public struct Int32
        {
            //....
        }
        // System.String (Reference Type)
        public sealed class String
        {
            //....
        }

        // 14-2) struct 구조체
        // 구조체 정의
        struct MyPoint
        {
            public int X;
            public int Y;

            public MyPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", X, Y);
            }
        }

        // 15-2) 간단한 C# 클래스
        public class MyCustomer
        {
            // 필드
            private string name;
            private int age;

            // 이벤트 
            public event EventHandler NameChanged;

            // 생성자 (Constructor)
            public MyCustomer()
            {
                name = string.Empty;
                age = -1;
            }

            // 속성
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        if (NameChanged != null)
                        {
                            NameChanged(this, EventArgs.Empty);
                        }
                    }
                }
            }
            public int Age
            {
                get { return this.age; }
                set { this.age = value; }
            }

            // 메서드
            public string GetCustomerData()
            {
                string data = string.Format("Name: {0} (Age: {1})",
                            this.name, this.age);
                return data;
            }
        }

        // 16-2) Nullable<T> 타입
        double _Sum = 0;
        DateTime _Time;
        bool? _Selected;

        public void CheckInput(int? i, double? d, DateTime? time, bool? selected)
        {
            if (i.HasValue && d.HasValue)
                this._Sum = (double)i.Value + (double)d.Value;

            // time값이 있는 체크.
            if (!time.HasValue)
                throw new ArgumentException();
            else
                this._Time = time.Value;

            // 만약 selected가 NULL이면 false를 할당
            this._Selected = selected ?? false;
        }

        // 16-3) Nullable 정적 클래스
        void NullableTest()
        {
            int? a = null;
            int? b = 0;
            int result = Nullable.Compare<int>(a, b);
            Console.WriteLine(result); //결과 -1

            double? c = 0.01;
            double? d = 0.0100;
            bool result2 = Nullable.Equals<double>(c, d);
            Console.WriteLine(result2); //결과 true
        }

        // 18-1) 이벤트
        // 클래스 내의 이벤트 정의
        /*
        class MyButton
        {
            public string Text;
            // 이벤트 정의
            public event EventHandler Click;

            public void MouseButtonDown()
            {
                if (this.Click != null)
                {
                    // 이벤트핸들러들을 호출
                    Click(this, EventArgs.Empty);
                }
            }
        }
        // 이벤트 사용
        public void Run()
        {
            MyButton btn = new MyButton();
            // Click 이벤트에 대한 이벤트핸들러로
            // btn_Click 이라는 메서드를 지정함
            btn.Click += new EventHandler(btn_Click);
            btn.Text = "Run";
            //....
        }
        void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 클릭");
        }
        */
        // 18-2) 이벤트: add와 remove
        class MyButton
        {
            // 이벤트 정의하는 다른 방법
            private EventHandler _click;
            public event EventHandler Click
            {
                add
                {
                    _click += value;
                    // _click = value;   // 싱글캐스트
                }
                remove
                {
                    _click -= value;
                }
            }

            public void MouseButtonDown()
            {
                if (this._click != null)
                {
                    // 이벤트핸들러들을 호출
                    _click(this, EventArgs.Empty);
                }
            }

            /* 속성 정의
            private string _name;
            public string Name 
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            */
        }

        static void Main(string[] args)
        {
            /*
            // 1. 프로그래밍 언어
            // 1) 아주 간단한 C# 프로그램
            System.Console.WriteLine("Hello World...");

            // 2) 코멘트
            // 코멘트: 한 라인 코멘트는 두개의 슬래시 사용함       
            int a = 1;
            int b = 1;  // 코멘트: 하나의 문장 뒤에 코멘트를 달 수 있음
            */
            /*
               복수 라인에 대한 코멘트
               int c;
               int d; 
            */

            // 3. 데이타 타입
            // 1) 데이타 타입 예제
            /*
            // Bool
            bool b = true;
            // Numeric
            short sh = -32768;
            int i = 2147483647;
            long l = 1234L;      // L suffix
            float f = 123.45F;   // F suffix
            double d1 = 123.45;
            double d2 = 123.45D; // D suffix
            decimal d = 123.45M; // M suffix
            // Char/String
            char c = 'A';
            string s = "Hello";
            // DateTime  2011-10-30 12:35
            DateTime dt = new DateTime(2011, 10, 30, 12, 35, 0);
            
            // 2) Nullable Type
            // Nullable 타입
            int? i = null;
            i = 101;
            bool? b = null;
            //int? 를 int로 할당
            Nullable<int> j = null;
            j = 10;
            int k = j.Value;
            
            // 4. 변수 및 상수
            // 1) 변수 예제
            // 테스트
            CSVar obj = new CSVar();
            obj.Method1();
            
            // 5. 배열
            // 1) 배열(Array)
            // 1차 배열
            string[] players = new string[10];
            string[] Regions = { "서울", "경기", "부산" };
            // 2차 배열 선언 및 초기화
            string[,] Depts = {{ "김과장", "경리부" },{ "이과장", "총무부" } }; // rectangle 배열 선언 전용 표기법
            Console.WriteLine(Depts[1,0]); // rectangle 배열의 인덱스 접근방법
            // 3차 배열 선언
            string[, ,] Cubes;

            // 2) 가변배열(Jagged Array)
            //Jagged Array (가변 배열)
            //1차 배열 크기(3)는 명시해야
            int[][] A = new int[3][];
            //각 1차 배열 요소당 서로 다른 크기의 배열 할당 가능
            A[0] = new int[2];
            A[1] = new int[3] { 1, 2, 3 };
            A[2] = new int[4] { 1, 2, 3, 4 };
            A[0][0] = 1; // 가변배열 인덱스 접근방법
            A[0][1] = 2;

            // 3) 배열의 사용
            int sum = 0;
            int[] scores = { 80, 78, 60, 90, 100 };
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            Console.WriteLine(sum);
            
            // 4) 배열의 전달
            int[] scores = { 80, 78, 60, 90, 100 };
            int sum = CalculateSum(scores); // 배열 전달: 배열명 사용
            Console.WriteLine(sum);

            // 6. 문자열
            // 1) 문자열
            // 문자열(string) 변수
            string s1 = "C#";
            string s2 = "Programming";
            // 문자(char) 변수 
            char c1 = 'A';
            char c2 = 'B';
            // 문자열 결합
            string s3 = s1 + " " + s2;
            Console.WriteLine("String: {0}", s3);
            // 부분문자열 발췌
            string s3substring = s3.Substring(1, 5);
            Console.WriteLine("Substring: {0}", s3substring);
            
            // 2) 문자열, 문자, 문자배열
            string s = "C# Studies";
            // 문자열을 배열인덱스로 한문자 엑세스 
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, s[i]);
            }
            // 문자열을 문자배열로 변환
            string str = "Hello";
            char[] charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.WriteLine(charArray[i]);
            }
            // 문자배열을 문자열로 변환
            char[] charArray2 = { 'A', 'B', 'C', 'D' };
            s = new string(charArray2);
            Console.WriteLine(s);
            // 문자 연산
            char c1 = 'A';
            char c2 = (char)(c1 + 3);
            Console.WriteLine(c2);  // D 출력
            
            // 3) StringBuilder 클래스
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 26; i++)
            {
                sb.Append(i.ToString());
                sb.Append(Environment.NewLine);
            }
            string s = sb.ToString();
            Console.WriteLine(s);

            // 7. 열거형 enum
            // 1) enum의 사용
            City myCity;
            // enum 타입에 값을 대입하는 방법
            myCity = City.Seoul;
            // enum을 int로 변환(Casting)하는 방법. 
            // (int)를 앞에 지정.
            int cityValue = (int)myCity;
            if (myCity == City.Seoul) // enum 값을 비교하는 방법
            {
                Console.WriteLine("Welcome to Seoul");
            }

            // 2) 플래그(flag) enum
            // OR 연산자로 다중 플래그 할당
            Border b = Border.Top | Border.Bottom;

            // & 연산자로 플래그 체크
            if ((b & Border.Top) != 0)
            {
                //HasFlag()이용 플래그 체크
                if (b.HasFlag(Border.Bottom))
                {
                    // "Top, Bottom" 출력
                    Console.WriteLine(b.ToString());
                }
            }
            
            // 9. 조건문
            // 1) if 조건문
            int a = -11;
            int val;
            if (a >= 0)
            {
                val = a;
            }
            else
            {
                val = -a;
            }
            // 출력값 : 11
            Console.WriteLine(val);

            // 2) switch 조건문
            string category = "사과";
            int price;
            switch (category)
            {
                case "사과":
                    price = 1000;
                    break;
                case "딸기":
                    price = 1100;
                    break;
                case "포도":
                    price = 900;
                    break;
                default:
                    price = 0;
                    break;
            }
            Console.WriteLine(price);
            
            // 3) 조건문 예제
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: MyApp.exe option");
                return;
            }
            string option = args[0];
            Console.WriteLine(option);
            switch (option.ToLower())
            {
                case "/v":
                case "/verbose":
                    verbose = true;
                    break;
                case "/c":
                    continueOnError = true;
                    break;
                case "/l":
                    logging = true;
                    break;
                default:
                    Console.WriteLine("Unknown argument: {0}", option);
                    break;
            }

            // 10. 반복문
            // 1) for 반복 구문
            // for 루프
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Loop {0}", i);
            }

            // 2) foreach 반복 구문
            string[] array = new string[] { "AB", "CD", "EF" };
            // foreach 루프
            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
            
            // 3) for vs. foreach
            // 3차배열 선언
            string[,,] arr = new string[,,] {
                { {"1", "2"}, {"11","22"} }, 
                { {"3", "4"}, {"33", "44"} }
            };
            //for 루프 : 3번 루프를 만들어 돌림
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.WriteLine(arr[i, j, k]);
                    }
                }
            }
            //foreach 루프 : 한번에 3차배열 모두 처리
            foreach (var s in arr)
            {
                Console.WriteLine(s);
            }
            
            // 4) while 반복 구문
            int i = 1;
            // while 루프
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }
            
            // 5) do while 반복 구문
            int i = 1;
            // do ~ while 루프
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);
            
            // 6) 반복 구문 예제
            List<char> keyList = new List<char>();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                keyList.Add(key.KeyChar);
            } while (key.Key != ConsoleKey.Q); // Q가 아니면 계속

            Console.WriteLine();
            foreach (char ch in keyList) // 리스트 루프
            {
                Console.Write(ch);
            }
            
            // 11. yield
            // 1) yield
            foreach (int num in GetNumber())
            {
                Console.WriteLine(num);
            }
            
            // 2) yield와 Enumerator
            // (1) foreach 사용하여 Iteration
            var list = new MyList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            // (2) 수동 Iteration
            IEnumerator<int> it = list.GetEnumerator();
            it.MoveNext();
            Console.WriteLine(it.Current);  // 1
            it.MoveNext();
            Console.WriteLine(it.Current);  // 2

            // 12. 예외 처리

            // 13. 네임스페이스
            
            // 14. 구조체
            // 1) Value Type vs Reference Type

            // 2) struct 구조체
            // 구조체 사용
            MyPoint pt = new MyPoint(10, 12);
            Console.WriteLine(pt.ToString());

            // 15. 클래스
            // 1) class (클래스)
            // 메서드(Method), 속성(Property), 필드(Field), 이벤트(Event)로 구성

            // 2) 간단한 C# 클래스
            MyCustomer me = new MyCustomer();
            me.Name = "jh";
            me.Age = 12;
            Console.WriteLine("{0}, {1}", me.Name, me.Age);
            Console.WriteLine(me.GetCustomerData());
            */
            // 16. Nullable 타입
            // 1) Nullable 타입의 도입
            // Value Type은 null을 가질 수 없지만, 가질 수 있게 해주는 구조체
            // int?와 같은 형식으로 선언하면 컴파일시 Nullable<T> 구조체로 변환된다.
            // 2) Nullable<T> 타입
            // 3) Nullable 정적 클래스

            // 17. 메서드 파라미터
            // 1) Pass by Value
            // 메서드에 인수를 전달할 때 값을 복사해서 전달하는 Pass by Value 방식을 따른다.
            // 그래서 메서드 안에서 인수가 바뀌어도 메서드 밖 인수는 바뀌지 않는다.
            // 2) Pass by Reference
            // 메서드 안에서 바뀐 인수를 밖으로 전달하는 방법은 2가지이다.
            // 하나는 ref로 참조하는 것, 하나는 out으로 바깥에 꺼내는 것.

            // 18. 이벤트
            // 1) 이벤트
            // # Main 메소드 위 참고
            // 2) 이벤트: add와 remove
            // # Main 메소드 위 참고

            // 19. 전처리기
            // 1) 전처리기 지시어(Preprocessor Directive)
            // 2) 조건별 컴파일
        /*
            #define TEST_ENV
            //#define PROD_ENV

            using System;

            namespace App1
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        bool verbose = false;
                        // ...

            #if (TEST_ENV)
                        Console.WriteLine("Test Environment: Verbose option is set.");
                        verbose = true;
            #else
                        Console.WriteLine("Production");
            #endif

                        if (verbose)
                        {
                            //....
                        }
                    }
                }
            }
        */

            // 3) #region 전처리기 지시어
        /*
            class ClassA
            {
                #region Public Methods        
                public void Run() { }
                public void Create() { }        
                #endregion

                #region Public Properties
                public int Id { get; set; }
                #endregion

                #region Privates
                private void Execute() { }
                #endregion
            }
        */

            // 4) 기타 전처리기 지시어
        /*
            // #warning 예제 -----------------------------------
            #if (!ENTERPRISE_EDITION)
            #warning This class should be used in Enterprise Edition
            #endif

            namespace App1 {
                class EnterpriseUtility {
                }
            }

            // #error 예제 --------------------------------------
            #define STANDARD_EDITION
            #define ENTERPRISE_EDITION

            #if (STANDARD_EDITION && ENTERPRISE_EDITION)
            #error Use either STANDARD or ENTERPRISE edition. 
            #endif

            namespace App1 {
                class Class1 {
                }
            }
        */

            // 5) #pragma 전처리기 지시어
        /*
            // CS3021 Warning을 Disable
            #pragma warning disable 3021

            namespace App1
            {
                [System.CLSCompliant(false)] 
                class Program
                {
                    static void Main(string[] args)
                    {
                        //...
        
            #pragma warning disable
                    if (false)
                    {
                        Console.WriteLine("TBD");
                    }
            #pragma warning restore
        
                        //...
                    }
                }
            }
        

            // 파일 입출력
            FileStream fsa = File.Create("a.txt");
            FileInfo file = new FileInfo("b.txt");
            FileStream fsb = file.Create();

            fsa.Close();
            fsb.Close();
            File.Copy("a.txt", "c.txt");
            FileInfo dst = file.CopyTo("d.txt");
            */
            // StreamWriter
            StreamWriter sw = new StreamWriter("a.txt");
            sw.Write("sw.Write()");
            sw.Write(" sw.Write()");
            sw.WriteLine(" sw.WriteLine()");
            sw.WriteLine("sw.WriteLine()");

            sw.Close();

            // StreamReader
            StreamReader sr = new StreamReader("a.txt");

            while (sr.Peek() >= 0)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
        }

        // 4) 배열의 전달
        static int CalculateSum(int[] scoresArray) // 배열 받는 쪽
        {
            int sum = 0;
            for (int i = 0; i < scoresArray.Length; i++)
            {
                sum += scoresArray[i];
            }
            return sum;
        }
    }
}
