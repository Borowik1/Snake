using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                pList.Add(new Point(x, y, sym));
            }
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Point point in pList)
            {
                point.Draw();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
