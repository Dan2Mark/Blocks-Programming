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
    class TextVarBlock : BaseTextBlock
    {

        ComboBox comboBox = null;
        public TextVarBlock (BaseBlock container) : base (container)
        {

            Padding = new Thickness(2);
            MinWidth = 30;
            comboBox = Other.VariablesStorage.getTextComboBox();
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
        protected override string GetValue()
        {
            string outstr = "";
            Dispatcher.Invoke(() =>
           {
               if (comboBox.SelectedIndex > 1)
                   if (Other.VariablesStorage.TextVariables.ContainsKey(comboBox.SelectedItem.ToString()))
                       outstr = Other.VariablesStorage.TextVariables[comboBox.SelectedItem.ToString()];
           });
            return outstr;
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

            if (comboBox.SelectedIndex > 1)
                return comboBox.SelectedItem.ToString();
            return "\"\"";
            
        }
    }
}
