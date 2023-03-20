using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Blocks_Programming.Other
{
    public class ConsoleBlock : Border
    {
        TextBox enter = new TextBox { IsEnabled = false, Margin = new System.Windows.Thickness(2) };
        TextBlock outPut = new TextBlock { Background = new SolidColorBrush(Color.FromRgb(230, 230, 230)), MinHeight = 50 };
        ScrollViewer scrollViewer = new ScrollViewer { Margin = new System.Windows.Thickness(2), Padding = new System.Windows.Thickness(2), Height = 60 };
        bool read = false;
        public void IsOpen  (bool flag, int cnt = 0)
        {
            if (flag)
            {
                if (cnt > 10)
                    cnt = 10;
                if (cnt < 4)
                    cnt = 4;
                Dispatcher.Invoke(() => scrollViewer.Height = cnt*20);
            }
            else
                Dispatcher.Invoke(() => scrollViewer.Height = 60);
            } 
        public bool Read { set
            {
                if (value)
                    allowWriting();
                else
                    disableWriting();
                read = value;
            } }
        public ConsoleBlock()
        {
            Background = new SolidColorBrush(Colors.LightGray);
            scrollViewer.Content = outPut;
            Child = new StackPanel
            {
                Children =
                {
                    enter,
                    scrollViewer
                }
            };
            KeyUp += PressEnter;
            MouseEnter += mouseEnter;
            MouseLeave += mouseLeave;
        }
        void PressEnter (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                read = false;
        }
        bool enterFlag = true;
        void mouseEnter(object sender, MouseEventArgs e)
        {
            if (enterFlag)
            {
                int count = 0;
                string str = outPut.Text;
                while (str.Contains("\n"))
                {
                    str = str.Remove(0,str.IndexOf("\n")+1);
                    count++;
                }
                if (count > 4)
                    IsOpen(true,count);
                enterFlag = false;
            }
        }
        void mouseLeave(object sender, MouseEventArgs e)
        {
            IsOpen(false);
            enterFlag = true;
        }
        public string GetText()
        {
            Read = true;
            while(read) { };
            string outstr = "";
            Dispatcher.Invoke(() => outstr = enter.Text);
            disableWriting();
            return outstr;
        }
        public void PrintText (string text)
        {
            Dispatcher.Invoke(() => outPut.Text += $"{text}\n");
        }
        public void ClearText()
        {
            Dispatcher.Invoke(() => outPut.Text = "");
        }
        public void allowWriting ()
        {
            Dispatcher.Invoke(() =>
            {
                enter.IsEnabled = true;
                enter.Focus();
            });
        }

        public void disableWriting()
        {

            Dispatcher.Invoke(() =>
            {
                enter.IsEnabled = false;
                enter.Text = "";
            });
        }
    }
}
