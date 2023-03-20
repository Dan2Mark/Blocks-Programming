using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blocks_Programming.Blocks.ReturnBlock.Text
{
    class Text : BaseTextBlock
    {
        TextBox child = new TextBox { Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 60) };
        public Text(BaseBlock container) : base(container)
        {
            Padding = new Thickness(2);
            MinWidth = 45;
            Child = child;
            MouseMove += BlockMove;
            MouseLeftButtonUp += MouseClick;
            canDrag = false;
        }
        protected override void BlockMove(object sender, MouseEventArgs e)
        {
            if (canDrag && e.LeftButton == MouseButtonState.Pressed && sender as BaseReturnBlock != null)
            {
                DragDrop.DoDragDrop((BaseBlock)sender, new DataObject(DataFormats.Serializable, sender), DragDropEffects.Move);
            }
        }
        void MouseClick(object sender, EventArgs e)
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

        protected override string GetValue()
        {
            string outstr = "";
            //Dispatcher.Invoke(() => outstr = child.Text);
            Dispatcher.Invoke(() => outstr = child.Text);
            return outstr;
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
            return $"\"{GetValue()}\"";
        }
    }
}
