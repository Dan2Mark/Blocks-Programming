using Blocks_Programming.Blocks.ReturnBlock.Compare;
using Blocks_Programming.Other;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Blocks_Programming.Blocks.CommandBlock
{
    class WhileBlock : BaseCommandBlock
    {
        TextBlock text = new TextBlock { Foreground = Themes.MainColors.DarkText};
        CompareContainer compare = null;
        public GroupBlock children;
        public WhileBlock(FrameworkElement container, int index) : base(container, index)
        {
            children = new GroupBlock(this);
            compare = new CompareContainer(this) { Margin = new Thickness(30,0,3,0), HorizontalAlignment = HorizontalAlignment.Right};
            Background = Themes.MainColors.Cycle;
            elements.Children.Add(new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 3),
                Children =
                {
                    text, compare
                }
            }
            ) ;
            elements.Children.Add(children);
            text.Text = "Доки ";
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
            int i = 0;
            BaseCompareBlock bcb = null;
            Dispatcher.Invoke(() => bcb = (BaseCompareBlock)compare.Child);
            while (bcb.getValue())
            {
                int cnt = 0;
                Dispatcher.Invoke(() => cnt = children.childrenContainer.Children.Count);
                if (cnt > 0)
                {
                    BaseCommandBlock bCb = null;
                    Dispatcher.Invoke(() => bCb = (BaseCommandBlock)children.childrenContainer.Children[0]);
                    bCb.DoCommand();
                }
                i++;
                if (i > 10000)
                {
                    console.PrintText("Ошибка: нескінчений цикл");
                    break;
                }
            }
        }
        public override bool IsRight()
        {
            return compare.IsRight();
        }
        public override string GetC_SharpCode(int c, int i)
        {
            var tab = GetCountTab(i);
            return $"\n{tab}while ({compare.GetC_SharpCode(c,i)})\n{tab}{{{GetChildrenCode(c + 1, i + 1, children)}{tab}}}";
        }
    }
}
