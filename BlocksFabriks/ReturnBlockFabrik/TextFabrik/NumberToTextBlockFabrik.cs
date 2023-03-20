using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik
{
    class NumberToTextBlockFabrik : BaseTextBlockFabrik
    {
        public NumberToTextBlockFabrik()
        {
            Background = Themes.MainColors.Text;
            Padding = new System.Windows.Thickness(3);
            Text = "Число у текст";
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                { new NumberContainer(null, false) { VerticalAlignment = VerticalAlignment.Center} }
            };
        MinWidth = 20;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new NumberToTextBlock(container);
        }
    }
}
