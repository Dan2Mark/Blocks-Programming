using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Number;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blocks_Programming.Bloks
{
    class Number : BaseNumberBlock
    {
        TextBox child = new TextBox { Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 60)};
        public Number(BaseBlock container) : base(container)
        {
            Padding = new Thickness(2);
            MinWidth = 30;
            Child = child;
            child.TextChanged += textChanged;
            MouseMove += BlockMove;
            MouseLeftButtonUp += MouseClick;
            canDrag = false;
            LostFocus += OutLost;
        }
        protected override void BlockMove(object sender, MouseEventArgs e)
        {
            if (canDrag && e.LeftButton == MouseButtonState.Pressed && sender as BaseReturnBlock != null)
            {
                DragDrop.DoDragDrop((BaseBlock)sender, new DataObject(DataFormats.Serializable, sender), DragDropEffects.Move);
            }  
        }
        void OutLost(object sender, EventArgs e)
        {
            child.Text = getValue().ToString();
        }
            void MouseClick (object sender, EventArgs e)
        {
            if (canDrag)
            {
                child.IsEnabled = true;
                canDrag = false;
            }
            else
            {
                child.IsEnabled = false;
                canDrag = true;
            }
        }
        
        void textChanged (object sender, EventArgs e)
        {
            string output = "";
            bool flag = true;
            if (child.Text.Length > 0)
                if (child.Text[0] == '-')
                    output = "-";
            foreach (char c in child.Text)
            {
                if (isNumb(c)) output += c;
                if (c == ',' && flag)
                {
                    output += c;
                    flag = false;
                }
            }
            child.Text = output;
        }
        bool isNumb (char a)
        {
            if (a >= '0' && a <= '9') return true;
            else return false;
        }

        protected override double GetValue()
        {
            double outNum = 0;
            Dispatcher.Invoke(() =>
            {
                if (child.Text.Length == 0)
                    outNum = 0;
                else
                {
                    if (child.Text[child.Text.Length - 1] == ',')
                        child.Text += '0';
                    outNum = Convert.ToDouble(child.Text);
                }
            });
            return outNum;
        }
        public void printData(object sender, MouseEventArgs e)
        {
            ToolTip = $"{getValue()}";
        }
        public override bool IsRight()
        {
            GetValue();
            return true;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            return GetValue().ToString();
        }
    }
}
