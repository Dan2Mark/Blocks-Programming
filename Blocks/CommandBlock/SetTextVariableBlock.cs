using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blocks_Programming.Blocks.CommandBlock
{
    class SetTextVariableBlock : BaseCommandBlock
    {
        ComboBox cbx = null;
        TextContainer tc = null;
        public SetTextVariableBlock(FrameworkElement container, int indx) : base(container, indx)
        {
            Background = Themes.MainColors.Print;
            elements.Orientation = Orientation.Horizontal;
            cbx = Other.VariablesStorage.getTextComboBox();
            tc = new TextContainer(this);
            elements.Children.Add(cbx);
            elements.Children.Add(new TextBlock { Text = "=" , Margin = new Thickness(10,0,10,0)});
            elements.Children.Add(tc);
            cbx.MouseEnter += mouseEnter;
            cbx.MouseLeave += mouseLeave;
        }
        void mouseEnter(object sender, EventArgs e)
        {
            canDrag = false;
        }

        void mouseLeave(object sender, EventArgs e)
        {
            canDrag = true;
        }
        protected override void Command()
        {

            BaseTextBlock btb = null;
            Dispatcher.Invoke(() => btb = (BaseTextBlock)tc.Child);
            string str = btb.getValue();
            Dispatcher.Invoke(() => Other.VariablesStorage.TextVariables[cbx.SelectedItem.ToString()] = str);
        }

        public override bool IsRight()
        {
            bool output = false;
            if (tc != null && cbx != null)
                if (tc.IsRight() && cbx.SelectedIndex > 1)
                {
                    output = true;
                }
            return output;
        }

        public override string GetC_SharpCode(int c, int i)
        {

            if (cbx.SelectedIndex > 1)
                return $"{GetCountTab(i)}{cbx.SelectedItem} = {tc.GetC_SharpCode(c, i)};";
            return "";

        }
    }
}
