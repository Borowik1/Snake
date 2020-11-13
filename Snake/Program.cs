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

            Walls walls = new Walls(width, height);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(width, height, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    GameOver(width, height, snake.Length());
                    break;
                }

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

        private static void GameOver(int width, int height, int score)
        {
            List<string> gameOver = new List<string>();
            gameOver.Add(@"  ________                          ");
            gameOver.Add(@" /  _____/ _____     _____    ____  ");
            gameOver.Add(@"/   \  ___ \__  \   /     \ _/ __ \ ");
            gameOver.Add(@"\    \_\  \ / __ \_|  Y Y  \\  ___/ ");
            gameOver.Add(@" \______  /(____  /|__|_|  / \___  >");
            gameOver.Add(@"        \/      \/       \/      \/ ");
            gameOver.Add("");
            gameOver.Add(@"      ____ ___  __  ____ _______ ");
            gameOver.Add(@"     /  _ \\  \/ /_/ __ \\_  __ \");
            gameOver.Add(@"    (  <_> )\   / \  ___/ |  | \/");
            gameOver.Add(@"     \____/  \_/   \___  >|__|   ");
            gameOver.Add(@"                       \/        ");

            int x = (width - 36) / 2;
            int y = (height - 14) / 2;
            for (int i = 0; i < gameOver.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(gameOver[i]);
            }

            Console.SetCursorPosition(x + 14, y + 15);
            Console.WriteLine("Your score: " + score);

            Console.SetCursorPosition(x + 10, y + 17);
            Console.WriteLine("Press any key to exit");
            Console.Read();


        }
    }
}
