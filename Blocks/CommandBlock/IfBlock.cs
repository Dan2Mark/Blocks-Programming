using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Blocks.ReturnBlock.Compare;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.CommandBlockFabrik;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Blocks_Programming.Blocks
{
    class IfBlock : BaseCommandBlock
    {        GroupBlock children = null;
        GroupBlock childrenElse = null;
        CompareContainer compare = null;
        public IfBlock(FrameworkElement container, int index) : base(container, index)
        {
            Background = Themes.MainColors.Condition;
            compare = new CompareContainer(this) { Margin = new Thickness(30,0,0,0)};
            children = new GroupBlock(this);
            childrenElse = new GroupBlock(this);
            elements.Children.Add(new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 3),
                Children =
                {
                    new TextBlock {Text = "Якщо", TextWrapping = TextWrapping.Wrap, Foreground = Themes.MainColors.DarkText },
                    compare
                }
            }
             );
            elements.Children.Add(children);
            elements.Children.Add(new TextBlock { Text = "Інакше", TextWrapping = TextWrapping.Wrap, Foreground = Themes.MainColors.DarkText , Margin = new Thickness(0,0,0,3)});
            elements.Children.Add(childrenElse);

        }

        public override bool TestOfCycleBlock(BaseCommandBlock sender)
        {
            if (this == sender)
                return true;
            foreach (var Elem in children.childrenContainer.Children)
                if ((Elem as BaseCommandBlock).TestOfCycleBlock(sender))
                    return true;
            foreach (var Elem in childrenElse.childrenContainer.Children)
                if ((Elem as BaseCommandBlock).TestOfCycleBlock(sender))
                    return true;
            return false;
        }
        protected override void Command()
        {
            if (((BaseCompareBlock)compare.Child).getValue())

            {
                int children_cnt = 0;
                Dispatcher.Invoke(() => children_cnt = children.childrenContainer.Children.Count);
                if (children_cnt > 0)
                {
                    BaseCommandBlock bcb = null;
                    Dispatcher.Invoke(() => bcb = ((BaseCommandBlock)children.childrenContainer.Children[0]));
                    bcb.DoCommand();
                }
            }
            else
            {
                int children_else_cnt = 0;
                Dispatcher.Invoke(() => children_else_cnt = childrenElse.childrenContainer.Children.Count);
                if (children_else_cnt > 0)
                {
                    BaseCommandBlock bcb = null;
                    Dispatcher.Invoke(() => bcb = ((BaseCommandBlock)childrenElse.childrenContainer.Children[0]));
                    bcb.DoCommand();
                }
            }
        }
        public override bool IsRight()
        {
            base.IsRight();
            return compare.IsRight();
        }

        public override string GetC_SharpCode(int c, int i)
        {
            var tab = GetCountTab(i);
            string Else = (childrenElse.childrenContainer.Children.Count > 0) ? $"\n{tab}else\n{tab}{{\n{GetChildrenCode(c, i + 1, childrenElse)}\n{tab}}}" : "";
            return $"\n{tab}if ({compare.GetC_SharpCode(c, i)})\n{tab}{{\n{GetChildrenCode(c, i + 1, children)}\n{tab}}}{Else}";
        }
    }
}
