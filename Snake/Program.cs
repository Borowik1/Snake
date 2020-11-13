using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 30;
            int width = 120;

            Console.SetBufferSize(width, height);

            HorizontalLine upLine = new HorizontalLine(0, width - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, width - 2, height - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, height - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, height - 1, width - 2, '+');

            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(4, 5, '*');

            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                Thread.Sleep(100);
                snake.Move();
            }


            Console.Read();
        }

    }
}
