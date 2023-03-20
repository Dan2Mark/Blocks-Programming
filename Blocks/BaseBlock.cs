using Blocks_Programming.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Blocks_Programming.Bloks
{
    public class BaseBlock : Border
    {
        protected FrameworkElement container = null;
        static protected ConsoleBlock console;
        static public void SetConsole (ConsoleBlock consoleBlock)
        {
            console = consoleBlock;
        }
        public BaseBlock()
        {
            //MinHeight = 20;
            HorizontalAlignment = HorizontalAlignment.Stretch;
            Effect = new DropShadowEffect
            {
                Color = new Color { A = 255, R = 0, G = 0, B = 0 },
                Direction = 230,
                ShadowDepth = 2,
                Opacity = 0.25,
                BlurRadius = 5,
               
            };
            CornerRadius = new CornerRadius(5);
            VerticalAlignment = VerticalAlignment.Top;
        }

        public virtual void Delete ()
        {

        }
        public virtual bool IsRight ()
        {
            return true;
        }
        public virtual string GetC_SharpCode(int c, int i)
        {
            return "";
        }
        protected string GetCountTab(int i)
        {
            string count_t = "";
            for (int j = 0; j < i; j++)
                count_t += "\t";
            return count_t;
        }
    }
}
