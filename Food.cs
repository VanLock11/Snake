using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private int x, y;
        private Random rd = new Random();

        public int X
        {
            get
            {
                return x;
            }


        }

        public int Y
        {
            get
            {
                return y;
            }


        }



        public void RandomDraw()
        {
            x = rd.Next(1, Console.WindowWidth);
            y = rd.Next(1, Console.WindowHeight);
            Console.SetCursorPosition(x, y);
            Console.Write('f');
        }
    }
}
