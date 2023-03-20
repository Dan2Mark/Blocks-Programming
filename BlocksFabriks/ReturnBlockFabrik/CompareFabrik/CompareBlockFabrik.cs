using Blocks_Programming.Blocks.ReturnBlock.Compare;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.CompareFabrik
{
    class CompareBlockFabrik : BaseCompareFabrik
    {
        public CompareBlockFabrik()
        {
            Text = "Порівняння чисел";
            Padding = new System.Windows.Thickness(3);
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new NumberContainer(null, false) { VerticalAlignment = VerticalAlignment.Center },
                    new ComboBox() { Items = { "<" }, IsEnabled = false, SelectedIndex = 0 },
                    new NumberContainer(null, false) { VerticalAlignment = VerticalAlignment.Center }
                }
            };
            MinWidth = 50;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new CompareBlock(container);
        }
    }
}
