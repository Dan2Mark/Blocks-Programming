using Blocks_Programming.Blocks.ReturnBlock.Number;
using Blocks_Programming.Blocks.ReturnBlock.Text;
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
    class CompareTextBlock : BaseCompareBlock
    {
        TextContainer firstValue = null;
        TextContainer secondValue = null;
        ComboBox Operator = new ComboBox { };
        public CompareTextBlock(BaseBlock container) : base(container)
        {
            foreach (var op in new string[] { "=", "Містить", "≠" })
            {
                Operator.Items.Add(op);
            }
            Operator.SelectedIndex = 0;
            firstValue = new TextContainer(this);
            secondValue = new TextContainer(this);
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
                string a = ((BaseTextBlock)firstValue.Child).getValue();
                string b = ((BaseTextBlock)secondValue.Child).getValue();
                int op = 0;
                Dispatcher.Invoke(() => op = Operator.SelectedIndex);
                switch (op)
                {
                    case -1: return false;
                    case 0: return a == b;
                    case 1: return a.Contains(b);
                    case 2: return a != b;
                }
            }
            return false;
        }

        public override bool IsRight()
        {
            bool output = false;
            if (firstValue.Child != null && secondValue.Child != null)
                if (firstValue.IsRight() && secondValue.IsRight())
                {
                    output = true;
                }
            return output;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            string a = ((BaseTextBlock)firstValue.Child).GetC_SharpCode(c, i);
            string b = ((BaseTextBlock)secondValue.Child).GetC_SharpCode(c, i);
            int op = Operator.SelectedIndex;
            switch (op)
            {
                case -1: return "false";
                case 0: return $"{a} == {b}";
                case 1: return $"{a}.Contains({b})";
                case 2: return $"{a} != {b}";
            }
            return "false";
        }
    }
}
