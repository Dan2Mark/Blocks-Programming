using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Number;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Blocks_Programming.Blocks
{
    class ArifmeticBlock : BaseNumberBlock
    {
        NumberContainer firstValue = null;
        NumberContainer secondValue = null;
        ComboBox Operator = new ComboBox { Background = Themes.MainColors.Number, VerticalAlignment = VerticalAlignment.Center };
        public ArifmeticBlock(BaseBlock container) : base(container)
        {
            foreach (var op in "+-*/^%")
            {
                Operator.Items.Add(op);
            }
            Operator.SelectedIndex = 0;
            firstValue = new NumberContainer(this) { VerticalAlignment = VerticalAlignment.Center };
            secondValue = new NumberContainer(this) { VerticalAlignment = VerticalAlignment.Center };
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new TextBlock{ Text = "(" , FontSize = 17, Foreground = Themes.MainColors.DarkText},
                    firstValue,
                    Operator,
                    secondValue,
                    new TextBlock{ Text = ")" , FontSize = 17, Foreground = Themes.MainColors.DarkText},
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
        protected override double GetValue()
        {
            if (secondValue.Child != null && firstValue.Child != null)
            {
                double a = ((BaseNumberBlock)firstValue.Child).getValue();
                double b = ((BaseNumberBlock)secondValue.Child).getValue();
                int op = 0;
                Dispatcher.Invoke(() => op = Operator.SelectedIndex);
                switch (op)
                {
                    case -1: return 0;
                    case 0: return a + b;
                    case 1: return a - b;
                    case 2: return a * b;
                    case 3: return a / b;
                    case 4: return Math.Pow(a, b);
                    case 5: return a % b;
                }
            }
            return 0;
        }

        public void printData(object sender, MouseEventArgs e)
        {
            ToolTip = $"{getValue()}";
        }
        public override bool IsRight()
        {
            bool output = false;
            if (firstValue.Child != null && secondValue.Child != null)
                if (((BaseNumberBlock)firstValue.Child).IsRight() && ((BaseNumberBlock)secondValue.Child).IsRight())
                {
                    output = true;
                }
            return output;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            string a = ((BaseNumberBlock)firstValue.Child).GetC_SharpCode(c,i);
            string b = ((BaseNumberBlock)secondValue.Child).GetC_SharpCode(c,i);
            int op = Operator.SelectedIndex; 
            switch (op)
            {
                case -1: return "0";
                case 0: return $"({a} + {b})";
                case 1: return $"({a} - {b})";
                case 2: return $"({a} * {b})";
                case 3: return $"({a} / {b})";
                case 4: return $"Math.Pow({a},{b})";
                case 5: return $"({a} % {b})";
            }
            return "";
        }
    }
}
