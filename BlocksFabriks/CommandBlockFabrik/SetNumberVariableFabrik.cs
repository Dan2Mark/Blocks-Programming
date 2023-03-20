using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Bloks;
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
    class SetNumberVariableFabrik : BaseCommandBlockFabrik
    {
        public SetNumberVariableFabrik()
        {
            Text = "Задати числову змінну";
            Background = Themes.MainColors.Print;
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new ComboBox() { Items = { "num_var" }, IsEnabled = false, SelectedIndex = 0 },
                    new TextBlock {Text = " = "},
                    new NumberContainer(null,false)
                }
            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx)
        {
            return new SetNumVariableBlock(container, indx);
        }
    }
}
