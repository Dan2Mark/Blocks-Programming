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
    class NumberVarBlock : BaseNumberBlock
    {
        ComboBox comboBox = null;
        public NumberVarBlock(BaseBlock container) : base(container)
        {
            Padding = new Thickness(2);
            MinWidth = 30;
            comboBox = Other.VariablesStorage.getNumberComboBox();
            Child = comboBox;

            comboBox.MouseEnter += mouseEnter;
            comboBox.MouseLeave += mouseLeave;
        }
        void mouseEnter(object sender, EventArgs e)
        {
            canDrag = false;
        }

        void mouseLeave(object sender, EventArgs e)
        {
            canDrag = true;
        }
        protected override double GetValue()
        {

            double outNum = 0;
            Dispatcher.Invoke(() =>
            {
                if (comboBox.SelectedIndex > 1)
                    if (Other.VariablesStorage.NumberVariables.ContainsKey(comboBox.SelectedItem.ToString()))
                        outNum = Other.VariablesStorage.NumberVariables[comboBox.SelectedItem.ToString()];
            });
            return outNum;
        }
        public void printData(object sender, MouseEventArgs e)
        {
            ToolTip = $"{getValue()}";
        }
        public override bool IsRight()
        {
            if (comboBox.SelectedIndex > 1)
                return true;
            return false;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            string outNum = "0";
            if (comboBox.SelectedIndex > 1)
                outNum = comboBox.SelectedItem.ToString();
            return outNum;
        }
    }
}
