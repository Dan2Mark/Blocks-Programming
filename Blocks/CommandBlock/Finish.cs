using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocks_Programming.Blocks.CommandBlock
{
    class Finish : BaseCommandBlock
    {
        Other.StartButton startBut = null;
        public Finish(FrameworkElement container, Other.StartButton startButton,int indx) : base(container, indx)
        {
            Visibility = Visibility.Hidden;
            AllowDrop = false;
            startBut = startButton;
        }
        protected override void Command()
        {
            console.IsOpen(false);
            console.Read = false;
            Dispatcher.Invoke(() => startBut.Stop());
        }
    }
}
