using Blocks_Programming.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Blocks_Programming.Other
{
    class CodeGeneratorButton : Button
    {
        Start start = null;
        public CodeGeneratorButton()
        {
            Height = 20;
            Margin = new System.Windows.Thickness(5);
            Click += click;
            AddChild(new TextBlock { Text = "Отримати код" , Margin = new Thickness(5,0,5,0)});
        }
        public void SetValues(Start start)
        {
            this.start = start;
        }
        void click(object sender, RoutedEventArgs e)
        {
            if (start.IsRight())
            {
                Clipboard.SetText(start.GetC_SharpCode(0, 0));
                MessageBox.Show("Текст скопійовано у буфер обміну");
            }
            else
                MessageBox.Show("Виправте помилки");
        }
    }
}
