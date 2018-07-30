using System;

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

    public struct StructParameters
    {
        public int value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();
            //pro.Methods1();
            pro.Overriding();
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
    }
}
