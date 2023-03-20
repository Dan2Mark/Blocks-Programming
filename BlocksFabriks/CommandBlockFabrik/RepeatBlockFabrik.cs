using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Bloks;
using System.Windows;
using System.Windows.Controls;
using Blocks_Programming.Teils;

namespace Blocks_Programming.BlocksFabriks.CommandBlockFabrik
{
    class RepeatBlockFabrik : BaseCommandBlockFabrik
    {
        public RepeatBlockFabrik()
        {
            Background = Themes.MainColors.Cycle;
            Text = "Повторити кілька разів";
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
                            new TextBlock { Text = "Повторити " },
                            new NumberContainer(null, false) { HorizontalAlignment = HorizontalAlignment.Right }
                        },
                        Margin = new Thickness(0, 0, 0, 3)
                    },
                    new GroupBlock(null, false),
                }

            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx = 0)
        {
            return new RepeatBlock(container, indx);
        }
    }
}
