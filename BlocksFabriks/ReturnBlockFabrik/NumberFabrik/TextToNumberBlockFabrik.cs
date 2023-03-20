using Blocks_Programming.Blocks;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik
{
    class TextToNumberBlockFabrik : BaseNumberBlockFabrik
    {
        public TextToNumberBlockFabrik()
        {
            Background = Themes.MainColors.Number;
            Text = "Текст у число";
            Padding = new System.Windows.Thickness(3);
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                { new TextContainer(null, false) { VerticalAlignment = VerticalAlignment.Center} }
            };
            MinWidth = 30;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new TextToNumberBlock(container);
        }

    }
}
