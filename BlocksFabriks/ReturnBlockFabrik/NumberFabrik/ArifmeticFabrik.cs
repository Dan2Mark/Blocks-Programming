using Blocks_Programming.Blocks;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik;
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
    class ArifmeticFabrik : BaseNumberBlockFabrik
    {
        public ArifmeticFabrik()
        {
            Background = Themes.MainColors.Number;
            Padding = new Thickness(1);
            Text = "Аріфметичні дії";
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new NumberContainer(null, false) { VerticalAlignment = VerticalAlignment.Center },
                    new ComboBox() { Items = { "+" }, IsEnabled = false, SelectedIndex = 0 },
                    new NumberContainer(null, false) { VerticalAlignment = VerticalAlignment.Center }
                }
            };
            MinWidth = 50;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new ArifmeticBlock(container);
        }
    }
}
