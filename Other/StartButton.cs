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
    class StartButton : Button
    {
        bool IsStarted = false;
        ConsoleBlock console = null;
        Start start = null;
        StackPanel startPanel = new StackPanel { Orientation = Orientation.Horizontal, Children = { new Polygon{ Points = { new Point(0, 0), new Point(0, 14), new Point(11, 7), new Point(0, 0) } , Fill = new SolidColorBrush(Colors.Green)}, new TextBlock { Text = "Пуск" , Margin = new Thickness(5,0,5,0)} } };
        StackPanel stopPanel = new StackPanel { Orientation = Orientation.Horizontal , Children = { new Polygon { Points = { new Point(0, 0), new Point(0, 12), new Point(12, 12), new Point(12, 0), new Point(0, 0) }, Fill = new SolidColorBrush(Colors.Red), Margin = new Thickness(2) }, new TextBlock { Text = "Стоп" , Margin = new Thickness(5, 0, 5, 0) } } };

        public StartButton ()
        {
            Height = 20;
            Width = 60;
            Margin = new System.Windows.Thickness(5);
            Click += click;
            Content = startPanel;
            
        }
        public void SetValues(ConsoleBlock console, Start start)
        {
            this.console = console;
            this.start = start;
        }
        void click(object sender, RoutedEventArgs e)
        {
            if (!IsStarted)
            {
                if (start.IsRight())
                {
                    Content = stopPanel;
                    console.ClearText();
                    console.IsOpen(true);
                    Task thr = Task.Factory.StartNew(() => start.DoCommand());
                    IsStarted = true;
                }
                else
                    MessageBox.Show("Виправте помилки");
            }
            else
                Stop();
        }
        public void Stop()
        {
            IsStarted = false;
            Content = startPanel;
            console.IsOpen(false);
            console.Read = false;

        }
    }
}
