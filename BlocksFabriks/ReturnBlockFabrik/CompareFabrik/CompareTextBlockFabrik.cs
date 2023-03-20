using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Blocks_Programming.Bloks;
using Blocks_Programming.Blocks.ReturnBlock.Compare;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.CompareFabrik
{
    class CompareTextBlockFabrik : BaseCompareFabrik
    {
        public CompareTextBlockFabrik()
        {
            Text = "Порівняння текста";
            Padding = new System.Windows.Thickness(3);
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new TextContainer(null, false) { VerticalAlignment = VerticalAlignment.Center },
                    new ComboBox() { Items = { "=" }, IsEnabled = false, SelectedIndex = 0 },
                    new TextContainer(null, false) { VerticalAlignment = VerticalAlignment.Center }
                }
            };
            MinWidth = 50;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new CompareTextBlock(container);
        }

    }
}
