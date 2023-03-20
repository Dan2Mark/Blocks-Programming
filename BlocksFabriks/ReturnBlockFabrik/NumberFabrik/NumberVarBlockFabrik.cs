using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik
{
    class NumberVarBlockFabrik : BaseNumberBlockFabrik
    {
        public NumberVarBlockFabrik()
        {
            Background = Themes.MainColors.Number;
            Text = "Числова Змінна";
            Padding = new Thickness(2);
            MinWidth = 30;
            var comboBox = new ComboBox();
            comboBox.Items.Add("var_num");
            comboBox.SelectedIndex = 0;
            comboBox.IsEnabled = false; 
            Child = comboBox;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new NumberVarBlock(container);
        }
    }
}
