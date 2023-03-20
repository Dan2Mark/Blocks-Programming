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

namespace Blocks_Programming.BlocksFabriks.CommandBlockFabrik
{
    class PrintBlockFabrik : BaseCommandBlockFabrik
    {
        public PrintBlockFabrik()
        {
            Background = Themes.MainColors.Print;
            Text = "Вивести інформацію";
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                { 
                    new TextBlock {Text = "Написати  "},
                    new TextContainer(null,false)
                }
            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx)
        {
            return new PrintBlock(container, indx);
        }
    }
}
