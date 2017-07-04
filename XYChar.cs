using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public struct XYChar
    {
        private int x;
        private int y;
        public char Ch
        { set; get; }

        public int X
        {
            get
            {
                return x;
            }

            set
            {

                if (value < Console.WindowWidth && value > 0)
                    x = value;
                else if (value >= Console.WindowWidth)
                    x = 1;
                else if (value <= 0)
                    x = Console.WindowWidth - 1;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (value < Console.WindowHeight && value > 0)
                    y = value;
                else if (value >= Console.WindowHeight)
                    y = 1;
                else if (value <= 0)
                    y = Console.WindowHeight - 1;
            }

        }

        public override string ToString()
        {
            return Ch.ToString();
        }
    }
}