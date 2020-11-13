using System;

namespace Snake
{
    internal class FoodCreator
    {
        private int width;
        private int height;
        private char v;

        Random random = new Random();

        public FoodCreator(int width, int height, char v)
        {
            this.width = width;
            this.height = height;
            this.v = v;
        }

        internal Point CreateFood()
        {
            int x = random.Next(2, width - 2);
            int y = random.Next(2, height - 2);
            return new Point(x, y, v);
        }
    }
}