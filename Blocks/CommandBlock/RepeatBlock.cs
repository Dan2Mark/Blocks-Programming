using Blocks_Programming.Blocks.ReturnBlock.Number;
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
    class RepeatBlock : BaseCommandBlock
    {
        NumberContainer blockRepeatCount = null;
        GroupBlock children = null;
        public RepeatBlock(FrameworkElement container, int index) : base(container, index)
        {
            blockRepeatCount = new NumberContainer(this);
            Background = Themes.MainColors.Cycle;
            children = new GroupBlock(this); 
            elements.Children.Add(new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                new TextBlock { VerticalAlignment = VerticalAlignment.Center, Foreground = Themes.MainColors.DarkText, Text = "Повторити " },
                blockRepeatCount
                },
                Margin = new Thickness(0,0,0,3)
            });
            elements.Children.Add(children);
        }
        public override bool TestOfCycleBlock(BaseCommandBlock sender)
        {
            if (this == sender)
                return true;
            foreach (var Elem in children.childrenContainer.Children)
                if ((Elem as BaseCommandBlock).TestOfCycleBlock(sender))
                    return true;
            return false;
        }
        protected override void Command()
        {
            int cnt = (int)((BaseNumberBlock)blockRepeatCount.Child).getValue();
            for (int i = 0; i < cnt ; i++)
            {

                int outNum = 0;
                Dispatcher.Invoke(() => outNum = children.childrenContainer.Children.Count);
                    if (outNum > 0)
                {
                    BaseCommandBlock bcb = null;
                    Dispatcher.Invoke(() => bcb = (BaseCommandBlock)children.childrenContainer.Children[0]);
                    bcb.DoCommand();
                }
            }
        }
        public override bool IsRight()
        {
            bool output = false;
            if (blockRepeatCount != null)
                if (blockRepeatCount.IsRight())
                {
                    output = true;
                }
            return output;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            var tab = GetCountTab(i);
            string nameVar = $"{(char)('a' + c)}";
            return $"\n{tab}for (int {nameVar} = 0; {nameVar} < {blockRepeatCount.GetC_SharpCode(c,i)}; {nameVar}++)\n{tab}{{{GetChildrenCode(c + 1, i + 1, children)}\n{tab}}}";
        }
    }
}
