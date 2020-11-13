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
            int width = 120;
            int height = 30;

            Console.SetBufferSize(width, height);

            HorizontalLine upLine = new HorizontalLine(0, width - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, width - 2, height - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, height - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, height - 1, width - 2, '+');

            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            VerticalLine vl = new VerticalLine(0, 10, 15, '%');
            Draw(vl);

            Point p = new Point(4, 5, '*');
            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            fSnake.Draw();
            Snake snake = (Snake)fSnake;

            HorizontalLine hl = new HorizontalLine(0, 5, 6, '&');

            List<Figure> figures = new List<Figure>();
            figures.Add(fSnake);
            figures.Add(vl);
            figures.Add(hl);

            foreach (Figure figure in figures)
            {
                figure.Draw();
            }

            FoodCreator foodCreator = new FoodCreator(width, height, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }           
        }

        private static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}
