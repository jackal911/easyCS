using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Dynamic;

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
    
    // 8-1) delegate의 개념
    class MyClass
    {
        // 1. delegate 선언
        private delegate void RunDelegate(int i);

        private void RunThis(int val)
        {
            // 콘솔출력 : 1024
            Console.WriteLine("{0}", val);
        }

        private void RunThat(int value)
        {
            // 콘솔출력 : 0x400
            Console.WriteLine("0x{0:X}", value);
        }

        public void Perform()
        {
            // 2. delegate 인스턴스 생성
            RunDelegate run = new RunDelegate(RunThis);
            // 3. delegate 실행
            run(1024);

            //run = new RunDelegate(RunThat); 을 줄여서 
            //아래와 같이 쓸 수 있다.
            run = RunThat;

            run(1024);
        }
    }
    // 9-1) delegate 필드와 delegate 속성
    class MyArea : Form
    {
        public MyArea()
        {
            // 이 부분은 당분간 무시 (무명메서드 참조)
            // 예제를 테스트하기 위한 용도임
            this.MouseClick += delegate { MyAreaClicked(); };
        }

        public delegate void ClickDelegate(object sender);

        // Delegate 필드
        public ClickDelegate MyClick;

        // 필드 대신 Delegate 속성으로도 가능
        // public ClickDelegate Click {get; set;}

        //...
        //...

        // 예제를 단순화 하기 위해
        // MyArea가 클릭되면 아래 함수가 호출된다고 가정
        void MyAreaClicked()
        {
            if (MyClick != null)
            {
                MyClick(this);
            }
        }
    }
    
    // 10-2) Event의 특성
    class MyArea : Form
    {
        public MyArea()
        {
            // 이 부분은 당분간 무시 (무명메서드 참조)
            // 예제를 테스트하기 위한 용도임
            this.MouseClick += delegate { MyAreaClicked(); };
        }

        public delegate void ClickEvent(object sender);

        // Delegate 필드
        public event ClickEvent MyClick;

        // 필드 대신 Delegate 속성으로도 가능
        // public ClickDelegate Click {get; set;}

        //...
        //...

        // 예제를 단순화 하기 위해
        // MyArea가 클릭되면 아래 함수가 호출된다고 가정
        void MyAreaClicked()
        {
            if (MyClick != null)
            {
                MyClick(this);
            }
        }
    }
    
    // 14-1) 확장 메서드 (Extension Method)
    public static class ExClass
    {
        public static string ToChangeCase(this String str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in str)
            {
                if (ch >= 'A' && ch <= 'Z')
                    sb.Append((char)('a' + ch - 'A'));
                else if (ch >= 'a' && ch <= 'z')
                    sb.Append((char)('A' + ch - 'a'));
                else
                    sb.Append(ch);
            }
            return sb.ToString();
        }

        public static bool Found(this String str, char ch)
        {
            int position = str.IndexOf(ch);
            return position >= 0;
        }
    }

    // 17-2) 익명타입에 dynamic 사용 예제
    // 동일 어셈블리에서 익명타입에 dynamic 사용한 경우
    class Class1
    {
        public void Run()
        {
            dynamic t = new { Name = "Kim", Age = 25 };

            var c = new Class2();
            c.Run(t);
        }
    }
    class Class2
    {
        public void Run(dynamic o)
        {
            // dynamic 타입의 속성 직접 사용
            Console.WriteLine(o.Name);
            Console.WriteLine(o.Age);
        }
    }
    */
    // 17-3) ExpandoObject 사용 예제
    //ExpandoObject
    public class Myclass
    {
        public void M1()
        {
            // ExpandoObject에서 dynamic 타입 생성
            dynamic person = new ExpandoObject();

            // 속성 지정
            person.Name = "Kim";
            person.Age = 10;

            // 메서드 지정
            person.Display = (Action)(() =>
            {
                Console.WriteLine("{0} {1}", person.Name, person.Age);
            });

            person.ChangeAge = (Action<int>)((age) =>
            {
                person.Age = age;
                if (person.AgeChanged != null)
                {
                    person.AgeChanged(this, EventArgs.Empty);
                }
            });

            // 이벤트 초기화
            person.AgeChanged = null; // dynamic 이벤트는 먼저 null 초기화함

            // 이벤트핸들러 지정
            person.AgeChanged += new EventHandler(OnAgeChanged);

            // 타 메서드에 파라미터로 전달
            M2(person);
        }

        private void OnAgeChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Age changed");
        }

        // dynamic 파라미터 전달받음
        public void M2(dynamic d)
        {
            // dynamic 타입 메서드 호출
            d.Display();
            d.ChangeAge(20);
            d.Display();
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
            new Program().Test();
            
            // 8. delegate 1
            // 1) delegate의 개념
            MyClass mc = new MyClass();
            mc.Perform();
            
            // 9. delegate 2
            // 1~2) delegate 필드와 delegate 속성
            area = new MyArea();
            //area.MyClick = Area_Click;
            area.MyClick += Area_Click;
            area.MyClick += AfterClick;

            area.ShowDialog();
            
            // 10. delegate 3
            // 1) Delegate에서 Event로
            area = new MyArea();

            area.MyClick += Area_Click;
            area.MyClick += AfterClick;

            area.Show();

            // 덮어쓰기: MyClick은 Area_Click메서드만 갖는다
            area.MyClick = Area_Click;

            // C# delegate는 클래스 외부에서 호출할 수 있다.
            // C# event는 불가
            area.MyClick(null);
            
            // 2) Event의 특성
            area = new MyArea();
            // 이벤트 가입
            area.MyClick += Area_Click;
            area.MyClick += AfterClick;
            // 이벤트 탈퇴
            area.MyClick -= Area_Click;

            // Error: 이벤트 직접호출 불가
            //area.MyClick(this);
            area.ShowDialog();

            // 11. 무명 메서드
            // 1) 무명 메서드(Anonymous Method)
            // 2) 무명 메서드 사용
            
            // 12. 람다식
            // 13. 익명 타입
            // 2) Anonymous Type 사용
            var v = new[] {
                new { Name="Lee", Age=33, Phone="02-111-1111" },
                new { Name="Kim", Age=25, Phone="02-222-2222" },
                new { Name="Park", Age=37, Phone="02-333-3333" },
            };
            // LINQ Select를 이용해 Name과 Age만 갖는 새 익명타입 객체들을 리턴.
            var list = v.Where(p => p.Age >= 30).Select(p => new { p.Name, p.Age });
            foreach (var a in list)
            {
                Console.WriteLine(a.Name + a.Age);
            }
            
            // 14. 확장메서드 1
            // 1) 확장 메서드 (Extension Method)
            string s = "This is a Test";
            string s2 = s.ToChangeCase();
            bool found = s.Found('z');
            Console.Write("{0}, {1}\n", s2, found);

            // 15. 확장메서드 2
            // 1) Enumerable 확장 메서드의 예제
            // Where 확장메서드를 List<T>에서 사용
            List<string> list = new List<string> { "Apple", "Grape", "Banana" };
            IEnumerable<string> q = list.Where(p => p.StartsWith("A"));

            List<int> nums = new List<int> { 55, 44, 33, 66, 11 };
            // Where 확장 메서드 정수 리스트에 사용
            var v = nums.Where(p => p % 3 == 0);
            // IEnumerable<int> 결과를 정수리스트로 변환
            List<int> arr = v.ToList<int>();
            // 리스트 출력
            arr.ForEach(n => Console.WriteLine(n));

            // 16. partial
            // 1) Partial Type
            dynamic a = "asdf";
            a = 1;
            
            // 17. dynamic
            // 1) dynamic 키워드

            // a. dynamic은 중간에 형을 변환할 수 있다.
            dynamic v = 1;
            // System.Int32 출력
            Console.WriteLine(v.GetType());
            v = "abc";
            // System.String 출력
            Console.WriteLine(v.GetType());

            // b. dynamic은 cast가 필요없다
            object o = 10;
            // o = o + 20; // 틀린표현
            // (에러: Operator '+' cannot be applied to operands of type 'object' and 'int')
            
            // 맞는 표현: object 타입은 casting이 필요하다
            o = (int)o + 20;
            // dynamic 타입은 casting이 필요없다.
            dynamic d = 10;
            d = d + 20;
            
            // 2) 익명타입에 dynamic 사용 예제
            // 3) ExpandoObject 사용 예제
            Myclass myclass = new Myclass();
            myclass.M1();
            */
            // 4) ExpandoObject의 dynamic 멤버 보기
            dynamic person = new ExpandoObject();            
            person.Name = "Kim";
            person.Age = 10;            
            person.Display = (Action)(() => { });
            person.ChangeAge = (Action<int>)((age) => { person.Age = age; });
            person.AgeChanged = null;
            person.AgeChanged += new EventHandler((s, e) => { });

            // ExpandoObject를 IDictionary로 변환
            var dict = (IDictionary<string, object>)person;

            // person 의 속성,메서드,이벤트는
            // IDictionary 해시테이블에 저정되어 있는데
            // 아래는 이를 출력함
            foreach (var d in dict)
            {
                Console.WriteLine("{0}: {1}", d.Key, d.Value);
            }
        }
        /*
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

        // 7-1) delegate 쉽게 이해하기
        delegate int MyDelegate(string s);
        void Test()
        {
            //델리게이트 객체 생성
            MyDelegate m = new MyDelegate(StringToInt);

            //델리게이트 객체를 메서드로 전달
            Run(m);
        }
        // 델리게이트 대상이 되는 어떤 메서드
        int StringToInt(string s)
        {
            return int.Parse(s);
        }

        // 델리게이트를 전달 받는 메서드
        void Run(MyDelegate m)
        {
            // 델리게이트로부터 메서드 실행
            int i = m("123");

            Console.WriteLine(i);
        }
        
        // 9-1~2) delegate 필드와 delegate 속성
        static MyArea area;

        static void Area_Click(object sender)
        {
            area.Text += "MyArea 클릭!";
        }

        // 9-2) Multicast Delegate
        static void AfterClick(object sender)
        {
            area.Text += " AfterClick 클릭! ";
        }
        */
    }
}
