using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Bloks;
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

namespace Blocks_Programming.BlocksFabriks.CommandBlockFabrik
{
    class WhileBlockFabrik : BaseCommandBlockFabrik
    {
        public WhileBlockFabrik()
        {
            Background = Themes.MainColors.Cycle;
            Text = "Повторяти доки виконується умова";
            Child = new StackPanel
            {

                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 0, 0, 3),
                Children =
                {
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Children =
                        {
                            new TextBlock {Text = "Доки"},
                            new CompareContainer(null, false) { Margin = new Thickness(30, 0, 3, 0), HorizontalAlignment = HorizontalAlignment.Right }
                        },
                        Margin = new Thickness(0,0,0,3)
                    },
                    new GroupBlock(null, false),
                }

            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx = 0)
        {
            return new WhileBlock(container, indx);
        }
    }
}
