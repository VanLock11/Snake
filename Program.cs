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
            //Create a thread for asynchronous work
            SnakeControler sneyk = new SnakeControler(10, 20);
            ThreadStart pressKeyFunction = new ThreadStart(sneyk.KeyControler);
            Thread thread_KeyControler = new Thread(pressKeyFunction);
            thread_KeyControler.Start();
            sneyk.Run();
            if (!sneyk.GameOver())
                thread_KeyControler.Abort();
         
           

        }
    }
}
