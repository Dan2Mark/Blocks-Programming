using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Number;
using Blocks_Programming.Blocks.ReturnBlock.Text;
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
    class TextToNumberBlock : BaseNumberBlock
    {
        TextContainer Value = null;
        public TextToNumberBlock(BaseBlock container) : base(container)
        {
                Value = new TextContainer(this) { VerticalAlignment = VerticalAlignment.Center };
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    Value,
                    }
            };
            MinWidth = 30;
        }
        protected override double GetValue()
        {
            if (Value.Child != null)
            {
                string str = ((BaseTextBlock)Value.Child).getValue();
                if (str != null)
                {
                    double a;
                    if (double.TryParse(str, out a))
                        return a;
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
            if (Value != null)
                if (Value.IsRight())
                {
                    output = true;
                }
            return output;
        }

        public override string GetC_SharpCode(int c, int i)
        {
            return $"Convert.ToDouble({Value.GetC_SharpCode(c,i)})";
        }
    }
}
