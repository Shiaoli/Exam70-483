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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Pi is {Math.GetPi()}");
            int x = Math.GetSquareOf(5);
            Console.WriteLine($"Square of 5 is {x}");
            var math = new Math();
            math.Value = 30;
            Console.WriteLine($"the value of the new Math instance is {math.Value}");
            Console.WriteLine($"the square of the value is {math.GetSquare()}");
            Console.WriteLine($"the static get square is {Math.GetSquareOf(10)}");
            //Console.WriteLine("Little Mao's GitHub travel is begining! Fighting!!");
            //Console.WriteLine("Hello World!");
        }
    }
}
