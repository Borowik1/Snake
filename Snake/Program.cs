using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            Func1(x);
            Console.WriteLine("Call Func1. x = " + x);

            x = 1;
            Func2(x);
            Console.WriteLine("Call Func2. x = " + x);

            x = 1;
            Func3(x);
            Console.WriteLine("Call Func3. x = " + x);

            Point p1 = new Point(1, 3, '*');
            Move(p1, 10, 10);

            Point p2 = new Point(4, 5, '#');
            Reset(p2);



        }

        private static void Reset(Point p2)
        {
            p2 = new Point();
        }

        private static void Move(Point p1, int v1, int v2)
        {
            p1.x = p1.x + v1;
            p1.y = p1.y + v2;
        }

        private static void Func3(int x)
        {
            x += 1;
        }

        private static void Func2(int value)
        {
            value += 1;
        }

        private static void Func1(int x)
        {
        }
    }
}
