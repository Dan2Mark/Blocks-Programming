using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Other;
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
    class PrintBlock : BaseCommandBlock
    {
        TextContainer textContainer = null;
        public PrintBlock(FrameworkElement container, int index) : base(container, index)
        {
            textContainer = new TextContainer(this);
            Background = Themes.MainColors.Print;
            elements.Children.Add(new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 3),
                Children =
                {
                    new TextBlock {Text = "Написати ", TextWrapping = TextWrapping.Wrap, Foreground = Themes.MainColors.DarkText, VerticalAlignment = VerticalAlignment.Center},
                    textContainer
                }
            }
             ) ;
            
        }
        protected override void Command()
        {
            BaseTextBlock baseTextBlock = null;
           Dispatcher.Invoke(() => baseTextBlock = (BaseTextBlock)textContainer.Child);
            if (baseTextBlock != null)
                console.PrintText(baseTextBlock.getValue());
        }
        public override bool IsRight()
        {
            bool output = false;
            if (textContainer != null)
                if (textContainer.IsRight())
                {
                    output = true;
                }
            return output;
        }

        public override string GetC_SharpCode(int c, int i)
        {
            var tab = GetCountTab(i);
            return $"{tab}Console.WriteLine({((BaseReturnBlock)textContainer.Child).GetC_SharpCode(c,i)});\n";
        }
    }
}
