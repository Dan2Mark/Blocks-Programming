using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik
{
    class TextVarBlockFabrik : BaseTextBlockFabrik
    {
        public TextVarBlockFabrik()
        {
            Background = Themes.MainColors.Text;
            Text = "Текстова Змінна";
            Padding = new Thickness(2);
            MinWidth = 30;
            var comboBox = new ComboBox();
            comboBox.Items.Add("var_text");
            comboBox.SelectedIndex = 0;
            comboBox.IsEnabled = false;
            Child = comboBox;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new TextVarBlock(container);
        }
    }
}
