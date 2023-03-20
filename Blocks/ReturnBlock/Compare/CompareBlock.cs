using Blocks_Programming.Blocks.ReturnBlock.Number;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blocks_Programming.Blocks.ReturnBlock.Compare
{
    class CompareBlock : BaseCompareBlock
    {
        NumberContainer firstValue = null;
        NumberContainer secondValue = null;
        ComboBox Operator = new ComboBox { };
        public CompareBlock(BaseBlock container) : base(container)
        {
            foreach (var op in new string[] { "<", ">", "≤", "≥", "=", "≠" })
            {
                Operator.Items.Add(op);
            }
            Operator.SelectedIndex = 0;
            firstValue = new NumberContainer(this) ;
            secondValue = new NumberContainer(this);
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    firstValue,
                    Operator,
                    secondValue,
                }
            };
            MinWidth = 50;
            Operator.MouseEnter += mouseEnter;
            Operator.MouseLeave += mouseLeave;
        }
        void mouseEnter(object sender, EventArgs e)
        {
            canDrag = false;
        }

        void mouseLeave(object sender, EventArgs e)
        {
            canDrag = true;
        }
        protected override bool GetValue()
        {

            if (secondValue.Child != null && firstValue.Child != null)
            {
                double a = ((BaseNumberBlock)firstValue.Child).getValue();
                double b = ((BaseNumberBlock)secondValue.Child).getValue();
                int op = 0;
                Dispatcher.Invoke(() => op = Operator.SelectedIndex);
                switch (op)
                {
                    case -1: return false;
                    case 0: return a < b;
                    case 1: return a > b;
                    case 2: return a <= b;
                    case 3: return a >= b;
                    case 4: return a == b;
                    case 5: return a != b;
                }
            }
            return false;
        }

        public void printData(object sender, MouseEventArgs e)
        {
            ToolTip = $"{getValue()}";
        }
        public override bool IsRight()
        {
            if (firstValue != null && secondValue != null)
                if (firstValue.IsRight() && secondValue.IsRight())
                {
                    return true;
                }
            return false;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            string a = ((BaseNumberBlock)firstValue.Child).GetC_SharpCode(c, i);
            string b = ((BaseNumberBlock)secondValue.Child).GetC_SharpCode(c, i);
            int op = Operator.SelectedIndex;
            switch (op)
            {
                case -1: return "false";
                case 0: return $"{a} < {b}";
                case 1: return $"{a} > {b}";
                case 2: return $"{a} <= {b}";
                case 3: return $"{a} >= {b}";
                case 4: return $"{a} == {b}";
                case 5: return $"{a} != {b}";
            }
            return "false";
        }
    }
}
