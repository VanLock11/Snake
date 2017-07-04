using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeControler z = new SnakeControler(10, 20);
           
         
           
                while (true)
                {
                    z.Run();
                }
           
           

        }
    }
}
