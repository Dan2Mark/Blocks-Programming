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
using System.Windows;

namespace Blocks_Programming.Blocks.ReturnBlock.Text
{
    class NumberToTextBlock : BaseTextBlock
    {
        NumberContainer Value = null;
        public NumberToTextBlock(BaseBlock container) : base(container)
        {
            Value = new NumberContainer(this) { VerticalAlignment = VerticalAlignment.Center };
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    Value,
                    }
            };
            MinWidth = 20;
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
            if (Value.Child != null)
            {
                return ((BaseNumberBlock)Value.Child).getValue().ToString();
            }
            return "";
        }

        public void printData(object sender, MouseEventArgs e)
        {
            ToolTip = $"{getValue()}";
        }
        public override bool IsRight()
        {
            bool output = false;
            if (Value != null)
                if (Value.IsRight())
                {
                    output = true;
                }
            return output;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            return $"{Value.GetC_SharpCode(c, i)}.ToString()";
        }
    }
}
