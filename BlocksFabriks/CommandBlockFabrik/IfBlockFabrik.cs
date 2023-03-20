using Blocks_Programming.Blocks;
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
using System.Windows.Media.Effects;

namespace Blocks_Programming.Blocks_Fabriks
{
    class IfBlockFabrik : BaseCommandBlockFabrik
    {
        public IfBlockFabrik ()
        {
            Background = Themes.MainColors.Condition;
            Text = "Виконується перший блок, якщо виуонуєтся умова,\n інакше виконується другий блок";

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
                            new TextBlock { Text = "Якщо" },
                            new CompareContainer(null, false) { Margin = new Thickness(30, 0, 3, 0), HorizontalAlignment = HorizontalAlignment.Right }
                        },
                        Margin = new Thickness(0, 0, 0, 3)
                    },
                    new GroupBlock(null, false),
                }

            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx = 0)
        {
            return new IfBlock(container, indx);
        }
    }
}
