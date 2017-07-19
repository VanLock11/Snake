using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class KeyEventArgs:EventArgs
    {
        private ConsoleKeyInfo _key = new ConsoleKeyInfo();
        public ConsoleKeyInfo _Key
        {
            set { _key = value; }
            get { return _key; }
        }
        public char Ch { set; get; }
    }

  public class KeyEvent
    {

        public event EventHandler<KeyEventArgs> KeyPress;
        public void OnKeyPress(ConsoleKeyInfo key)
        {

            KeyEventArgs k = new KeyEventArgs();
            if (KeyPress != null)
            {
                k._Key = key;
                KeyPress(this, k);
            }
        }

    }
}
