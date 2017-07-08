using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{
    class SnakeControler
    {

        private int ux = 1;
        private int x, y;
        private Food food = new Food();
        private List<XYChar> list = new List<XYChar>();
        private XYChar ii = new XYChar();
        public SnakeControler(int xx = 5, int yy = 5)
        {
            food.RandomDraw();
            X = xx;
            Y = yy;
            ii.X = xx;
            ii.Y = y;
            ii.Ch = '*';
            list.Add(ii);




        }



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

        public void ReadPress()
        {
            while (true) { 
            ConsoleKey d = Console.ReadKey().Key;
                switch (d)
                {
                    case ConsoleKey.LeftArrow:
                        ux = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        ux = 1;
                        break;
                    case ConsoleKey.UpArrow:
                        ux = 2;
                        break;
                    case ConsoleKey.DownArrow:
                        ux = -2;
                        break;

                }
          
            }




        }

        public void FoodReakcion()
        {
            if (food.X == X && food.Y == Y)
            {
                food.RandomDraw();
                ii.X = X;
                ii.Y = Y;
                ii.Ch = '*';
                list.Add(ii);
            }
        }

        public void Muve()
        {
            switch (ux)
            {
                case 1:

                    ii.X = ++X;
                    ii.Y = Y;
                    list[list.Count - 1] = ii;


                    break;
                case -1:

                    ii.X = --X;
                    ii.Y = Y;
                    list[list.Count - 1] = ii;

                    break;
                case 2:

                    ii.Y = --Y;
                    ii.X = X;
                    list[list.Count - 1] = ii;

                    break;
                case -2:

                    ii.Y = ++Y;
                    ii.X = X;
                    list[list.Count - 1] = ii;

                    break;
                default:
                    break;
            }

            if (list.Count > 1)
                RemoveIndex(list.Count - 1, 0);
        }

        private void RemoveIndex(int ver, int ar)
        {
            XYChar k = new XYChar(), c = new XYChar();
            k = list[ar];
            list[ar] = list[ver];
            for (int i = ar + 1; i <= ver; i++)
            {
                c = list[i];
                list[i] = k;
                k = c;
            }
        }
        void Draw()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(list[i].X, list[i].Y);
                Console.Write(list[i]);
            }
        }
        public void UnDraw()
        {

            Console.SetCursorPosition(list[list.Count - 1].X, list[list.Count - 1].Y);
            Console.WriteLine(' ');
            Console.SetCursorPosition(X, Y);
        }
        public void Run()
        {

            while (true)
            {
                Draw();
                Thread.Sleep(100);
                UnDraw();
                Muve();
                FoodReakcion();
            }




        }

    }
}
