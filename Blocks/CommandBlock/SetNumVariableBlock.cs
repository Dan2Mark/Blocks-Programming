using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Number;
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
    class SetNumVariableBlock : BaseCommandBlock
    {
        ComboBox cbx = null;
        NumberContainer nc = null;
        public SetNumVariableBlock(FrameworkElement container, int indx) : base(container, indx)
        {
            Background = Themes.MainColors.Print;
            elements.Orientation = Orientation.Horizontal;
            cbx = Other.VariablesStorage.getNumberComboBox();
            nc = new NumberContainer(this);
            elements.Children.Add(cbx);
            elements.Children.Add(new TextBlock { Text = "=" , Margin = new Thickness(10,0,10,0)});
            elements.Children.Add(nc);
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
            BaseNumberBlock bnb = null;
            Dispatcher.Invoke(() =>  bnb = (BaseNumberBlock)nc.Child);
            double outNum = bnb.getValue();
            Dispatcher.Invoke(() => Other.VariablesStorage.NumberVariables[cbx.SelectedItem.ToString()] = outNum);
        }
        public override bool IsRight()
        {
            bool output = false;
            if (nc != null && cbx != null)
                if (nc.IsRight() && cbx.SelectedIndex > 1)
                {
                    output = true;
                }
            return output;
        }
        public override string GetC_SharpCode(int c, int i)
        {

            if (cbx.SelectedIndex > 1)
                return $"{GetCountTab(i)}{cbx.SelectedItem} = {nc.GetC_SharpCode(c, i)};";
            return "";

        }
    }
}
