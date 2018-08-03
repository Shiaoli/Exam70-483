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
            pro.ConnectedListTest();
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
    }
}
