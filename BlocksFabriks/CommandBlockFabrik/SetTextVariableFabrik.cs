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
    class SetTextVariableFabrik : BaseCommandBlockFabrik
    {
        public SetTextVariableFabrik()
        {
            Text = "Задати текстову змінну";
            Background = Themes.MainColors.Print;
            Child = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new ComboBox() { Items = { "text_var" }, IsEnabled = false, SelectedIndex = 0 },
                    new TextBlock {Text = " = "},
                    new TextContainer(null,false)
                }
            };
        }
        public override BaseBlock Create(FrameworkElement container, int indx)
        {
            return new SetTextVariableBlock(container, indx);
        }
    }
}
