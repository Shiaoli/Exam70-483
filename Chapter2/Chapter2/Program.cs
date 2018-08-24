using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter2
{
    public class Math
    {
        public int Value { get; set; }
        public int GetSquare() => Value * Value;
        public static int GetSquareOf(int x) => x * x;
        public static double GetPi() => 3.14;
    }

    public class ClassParameters
    {
        public int value { get; set; }
    }

    //overriding base class
    public class Base
    {
        public void Execute() { Console.WriteLine("Base executed!"); }
    }

    public class Derived : Base
    {
        public new void Execute() { Console.WriteLine("Derived executed!"); }
    }

    //
    public class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public int Area()
        {
            return Height * Width;
        }
    }

    public class Square : Rectangle
    {
        public Square(int size):base(size, size)
        {

        }

        public override int Width { get => base.Width; set { base.Width = value; base.Height = value; }  }
        public override int Height { get => base.Height; set { base.Height = value; base.Width = value; } }
    }

    public struct StructParameters
    {
        public int value { get; set; }
    }

    // IComparable interface
    public class Order : IComparable
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Order o = obj as Order;
            if (o == null)
            {
                throw new ArgumentException("Object is not an order");
            }
            return this.Created.CompareTo(o.Created);
        }
    }

    public class ListNode
    {
        public ListNode(object value)
        {
            Value = value;
        }

        public object Value { get; private set; }

        public ListNode Next { get; internal set; }
        public ListNode Prev { get; internal set; }
    }

    public class ConnectedList: IEnumerable
    {
        public ListNode First { get; private set; }
        public ListNode Last { get; private set; }

        public ListNode AddNew(object node)
        {
            var newNode = new ListNode(node);
            if(First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                var previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }

        public IEnumerator GetEnumerator()
        {
            ListNode current = First;
            if(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }

    public class FieldsPractice
    {
        public const string s1 = "this is a const field";
        public string s2 = "this is not a const field";
    }

    public struct NewSquare
    {
        public NewSquare(int length, int height)
        {
            Length = length;
            Height = height;
        }
        public int Length { get; set; }
        public int Height { get; set; }
        
        public int Area => Length * Height;
    }

    public class ClassSquare
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public ClassSquare(int length, int height)
        {
            Length = length;
            Height = height;
        }
        public int Area => Length * Height;
    }

    public static class StringExtension
    {
        public static int GetWordCount(this string s) => s.Split().Length;
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    public class Size
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override string ToString()
        {
            return $"Height: {Height}, Width: {Width}";
        }
    }

    public class Shape
    {
        public Position Position { get; } = new Position();
        public Size Size { get; } = new Size();
        public virtual void Draw() => Console.WriteLine($"Shape with {Position} and {Size}");
    }

    public class NewShape : Shape
    {
        public override void Draw() => Console.WriteLine($"Rectangle with {Position} and {Size}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();
            //pro.Methods1();
            //pro.Overriding();
            //pro.Liskov();
            //pro.Interfaces();
            //pro.EnumeTest();
            //pro.ConnectedListTest();
            //pro.ArraryTest();
            //pro.OperatorPractice();
            //pro.StrucVCClass();
            //pro.StringEx();
            pro.ShapeMethod();
        }

        public void ShapeMethod()
        {
            var n = new NewShape();
            n.Position.X = 10;
            n.Position.Y = 12;
            n.Size.Height = 14;
            n.Size.Width = 16;
            n.Draw();
            //shape.Position = p;

        }

        public void StringEx()
        {
            string s1 = "this is a test";
            Console.WriteLine(s1.GetWordCount());
        }
        public void StrucVCClass()
        {
            var StructSquare = new NewSquare();
            StructSquare.Height = 5;
            StructSquare.Length = 8;
            //Console.WriteLine(StructSquare.Area);
            ForStrucVSClass(ref StructSquare);
            //Console.WriteLine(StructSquare.Area);
            string input1 = Console.ReadLine();
            int result1 = int.Parse(input1);
            Console.WriteLine($"result: {result1}");

        }

        public void ForStrucVSClass(ref NewSquare A)
        {
            A.Height = 12;
        }

        public void FieldMethod()
        {
            FieldsPractice f1 = new FieldsPractice();
            Console.WriteLine(f1.s2);
        }

        public void OperatorPractice()
        {
            int? a = null;
            int b = 10;
            if(a < b)
            {
                Console.WriteLine("I'm in if, haha");
            }
            else
            {
                Console.WriteLine("I'm in else, haha");
            }

            int? a1 = null;
            int b1;
            b1 = a1 ?? 10;
            a1 = 2;
            b1 = a1 ?? 10;
            int x = 1;
            int y = 2;
            int z = 3;
            x = y = z;
            Console.WriteLine($"the values of x y z is {x}, {y}, {z}");
        }

        public void ConnectedListTest()
        {
            var aList = new ConnectedList();
            aList.AddNew(10);
            aList.AddNew(20);
            aList.AddNew(30);
            foreach(var i in aList)
            {
                Console.WriteLine(i);
            }
        }

        // Involking methods
         public void Methods1()
        {
            Console.WriteLine($"Pi is {Math.GetPi()}");
            int x = Math.GetSquareOf(5);
            Console.WriteLine($"Square of 5 is {x}");
            var math = new Math();
            math.Value = 30;
            Console.WriteLine($"the value of the new Math instance is {math.Value}");
            Console.WriteLine($"the square of the value is {math.GetSquare()}");
            Console.WriteLine($"the static get square is {Math.GetSquareOf(10)}");
        }

        // Passing parameters by value
        public void ClassParametersMethod()
        {
            ClassParameters classParameters = new ClassParameters();
            classParameters.value = 10;

        } 

        public void Overriding()
        {
            Base b = new Base();
            b.Execute();
            b = new Derived();
            b.Execute();
        }

        public void Liskov()
        {
            Rectangle rectangle = new Square(5);
            rectangle.Width = 10;
            Console.WriteLine("the area of the square is " + rectangle.Area());

        }

        public void Interfaces()
        {
            List<Order> orders = new List<Order>
            {
                new Order {Created = new DateTime(2005,12,2)},
                new Order {Created = new DateTime(2010,10,21)},
                new Order {Created = new DateTime(2006,3,3)},
            };
            orders.Sort();
            foreach(var i in orders)
            {
                Console.WriteLine(i + "and");
            }
        }

        public void EnumeTest()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            using(List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override string ToString()
            => $"{FirstName} {LastName}";
        }
        public void ArraryTest()
        {
            // simplest way do define a one-dimension array
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            for(int i=0; i<array1.Length; i++)
            {
                Console.WriteLine(array1[i]);
            }

            // 
            Person[] TwoPerson =
            {
                new Person {FirstName = "Name1", LastName="Lastname1"},
                new Person {FirstName = "Name2", LastName="Lastname2"}
            };
            foreach(var i in TwoPerson)
            {
                Console.WriteLine(i.ToString());
            }

            // two dimensional array

            int[,] twoDimension =
            {
                {1,2,3 },
                {2,3,4 },
                {3,4,5 }
            };

        }
    }
}
