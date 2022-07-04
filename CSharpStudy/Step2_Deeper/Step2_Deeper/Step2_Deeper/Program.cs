using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// CSharpStudy 고급 문법 노트
namespace Step2_Deeper
{
    /*
    // 1-1) 인덱서 정의
    class MyClass{
        private const int MAX = 10;
        private string name;

        // 내부의 정수 배열 데이타
        private int[] data = new int[MAX];

        // 인덱서 정의. int 파라미터 사용
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= MAX)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    // 정수배열로부터 값 리턴
                    return data[index];
                }
            }
            set
            {
                if (!(index < 0 || index >= MAX))
                {
                    // 정수배열에 값 저장
                    data[index] = value;
                }
            }
        }
    }

    // 3-1) 파생클래스
    // 베이스 클래스
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // 파생클래스
    public class Dog : Animal
    {
        public void HowOld()
        {
            // 베이스 클래스의 Age 속성 사용
            Console.WriteLine("나이: {0}", this.Age);
        }
    }

    public class Bird : Animal
    {
        public void Fly()
        {
            Console.WriteLine("{0}가 날다", this.Name);
        }
    }

    // 3-2) 추상 클래스 (Abstract Class)
    public abstract class PureBase
    {
        // abstract C#키워드 
        public abstract int GetFirst();
        public abstract int GetNext();
    }

    public class DerivedA : PureBase
    {
        private int no = 1;

        // override C#키워드 
        public override int GetFirst()
        {
            return no;
        }

        public override int GetNext()
        {
            return ++no;
        }
    }

    // 3-3) public / protected 멤버
    public class MyBase
    {
        public string Name { get; set; }
        protected int Age { get; set; }
    }

    public class MyDerived : MyBase
    {
        public void Run()
        {
            // 파생클래스이므로 Age 사용 가능
            Console.WriteLine("나이: {0}", this.Age);
        }
    }
    */
    // 3-4) as 연산자와 is 연산자
    class MyBase
    {
        public int age = 13;
    }
    class MyClass : MyBase
    {
        public string name = "헤롱";
    }

    // 4-3) static 클래스
    public static class MyUtility
    {
        private static int ver;

        // static 생성자
        static MyUtility()
        {
            ver = 1;
        }

        public static string Convert(int i)
        {
            return i.ToString();
        }

        public static int ConvertBack(string s)
        {
            return int.Parse(s);
        }
    }

    // 5-1) 제네릭 (C# Generics)
    class MyStack<T>
    {
        T[] _elements;
        int pos = 0;

        public MyStack()
        {
            _elements = new T[100];
        }

        public void Push(T element)
        {
            _elements[++pos] = element;
        }

        public T Pop()
        {
            return _elements[pos--];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            // 1. Indexer
            // 1) 인덱서 정의
            MyClass cls = new MyClass();
            
            // 인덱서 set 사용
            cls[1] = 1024;

            // 인덱서 get 사용
            int i = cls[1];
            Console.WriteLine(i);

            // 2. 접근 제한자
            
            // 3. 클래스 상속
            // 1) 파생클래스
            // 2) 추상 클래스 (Abstract Class)
            // 3) public / protected 멤버
            // 4) as 연산자와 is 연산자
            MyClass c = new MyClass();
            new Program().Test(c);
            Console.WriteLine(c.name);

            // 4. 정적 static
            // 1) static 메서드
            // 반드시 클래스며.메서드명 으로 호출해야 됨. 인스턴스 생성 불가
            // 메서드 내부에서 클래스의 인스턴스 객체 멤버를 참조해서는 안된다.
            // 2) static 속성, 필드
            // 3) static 클래스
            string str = MyUtility.Convert(123);
            int i = MyUtility.ConvertBack(str);

            // 5. 제네릭
            // 1) 제네릭 (C# Generics)
            MyStack<int> numberStack = new MyStack<int>();
            MyStack<string> nameStack = new MyStack<string>();
            numberStack.Push(1);
            Console.WriteLine(numberStack.Pop());
            nameStack.Push("ㅇ");
            Console.WriteLine(nameStack.Pop());
            */
            // 2) .NET Generic 클래스들
            List<string> nameList = new List<string>();
            nameList.Add("홍길동");
            nameList.Add("이태백");
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["길동"] = 100;
            dic["태백"] = 90;
            foreach (var scores in dic)
            {
                Console.WriteLine(scores);
            }

            // 6. 인터페이스
            // 1) 인터페이스
            // 2) 인터페이스의 정의
            // 3) 인터페이스의 구현
            // 4) 인터페이스의 사용

            // 7. delegate 기초
            // 1) delegate 쉽게 이해하기
        }

        // 3-4)
        public void Test(object obj)
        {
            // as 연산자
            MyBase a = obj as MyBase;
            Console.WriteLine(a.age);
            // Console.WriteLine(a.name); // 베이스 class에선 name사용 불가

            MyClass c = obj as MyClass;
            Console.WriteLine(c.name); //  파생 class에선 사용 가능

            // is 연산자
            bool ok = obj is MyBase; // true
            Console.WriteLine(ok);

            // Explicit Casting
            MyBase b = (MyBase)obj;
            Console.WriteLine(b.age);
        }
    }
}
