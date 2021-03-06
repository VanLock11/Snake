﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{

    class SnakeControler
    {
        enum Direction
        {
            Left,
            Right,
            Down,
            Up
        }
        private KeyEvent keyt = new KeyEvent();


        private int ux = (int)Direction.Right;
        private int x, y;
        private Food food = new Food();
        private List<XYChar> list = new List<XYChar>();
        private XYChar ii = new XYChar();

        //Constructor 
        public SnakeControler(int xx = 5, int yy = 5)
        {
            food.RandomDraw();
            X = xx;
            Y = yy;
            ii.X = xx;
            ii.Y = y;
            ii.Ch = '*';
            list.Add(ii);


            keyt.KeyPress += (tt, e) =>
            {
                switch (e._Key.Key)
                {

                    case ConsoleKey.RightArrow:

                        ux = (int)Direction.Right;
                        break;
                    case ConsoleKey.LeftArrow:
                        ux = (int)Direction.Left;

                        break;
                    case ConsoleKey.UpArrow:
                        ux = (int)Direction.Up;

                        break;
                    case ConsoleKey.DownArrow:
                        ux = (int)Direction.Down;

                        break;
                    default:
                        break;

                }
                if (list.Count > 1)
                    RemoveIndex(list.Count - 1, 0);
            };

        }

        //Variable to cordinats
        private int X
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
        private int Y
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

        //Food Controler 
        public void FoodReakcion()
        {
            if (food.X == X && food.Y == Y)
            {
                Console.SetCursorPosition(food.X, food.Y);
                Console.Write(' ');
                food.RandomDraw();
                ii.X = X;
                ii.Y = Y;
                ii.Ch = '*';
                list.Add(ii);
            }
        }

        //Key input processing with event .To facilitate working in Main
        public void KeyControler()
        {

            while (GameOver())
            {
                ConsoleKeyInfo d = new ConsoleKeyInfo();
                d = Console.ReadKey();
                keyt.OnKeyPress(d);
            }
        }

        //Permutation of indices
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

        //Draw Snaeke 1element
        void Draw()
        {


            Console.SetCursorPosition(X, Y);
            Console.Write(list[0]);

        }


        //Delete Snake end element
        public void UnDraw()
        {

            Console.SetCursorPosition(list[list.Count - 1].X, list[list.Count - 1].Y);
            Console.WriteLine(' ');

        }

        //Necessary function to facilitate working in Main
        public void Run()
        {
            while (GameOver())
            {

                Draw();
                Thread.Sleep(90);
                UnDraw();
                Muve();
                FoodReakcion();

            }
        }

        //Mechanics of coordinate motion
        public void Muve()
        {
            switch ((Direction)ux)
            {

                case Direction.Right:
                    {

                        ii.X = ++X;
                        ii.Y = Y;
                        list[list.Count - 1] = ii;

                    }
                    break;
                case Direction.Left:
                    {

                        ii.X = --X;
                        ii.Y = Y;
                        list[list.Count - 1] = ii;

                    }
                    break;
                case Direction.Up:
                    {

                        ii.Y = --Y;
                        ii.X = X;
                        list[list.Count - 1] = ii;

                    }


                    break;
                case Direction.Down:
                    {

                        ii.Y = ++Y;
                        ii.X = X;
                        list[list.Count - 1] = ii;

                    }
                    break;
                default:
                    break;

            }
            if (list.Count > 1)
                RemoveIndex(list.Count - 1, 0);
        }

        //Variable to facilitate completion
        public bool GameOver()
        {
            if (list.Count > 4)
            {
                for (int i = 1; i < list.Count - 1; i++)
                {
                    if (list[0].X == list[i].X && list[0].Y == list[i].Y)
                    {
                        OnGameOver();
                        return false;
                    }
                }
            }
            return true;
        }

        //The end
        public void OnGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2);
            Console.WriteLine("Game Over!!!");
        }
    }
}
