using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        int width;
        int height;
        List<Figure> wallsList;

        public Walls(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        internal bool IsHit(Figure figure)
        {
            foreach (Figure wall in wallsList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

        internal void Draw()
        {
            HorizontalLine upLine = new HorizontalLine(0, width - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, width - 2, height - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, height - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, height - 1, width - 2, '+');

            wallsList = new List<Figure>();
            wallsList.Add(upLine);
            wallsList.Add(downLine);
            wallsList.Add(leftLine);
            wallsList.Add(rightLine);

            foreach (Figure figure in wallsList)
                figure.Draw();
        }
    }
}
