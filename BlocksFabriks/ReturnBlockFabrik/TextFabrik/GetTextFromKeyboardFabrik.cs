using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Bloks;
using Blocks_Programming.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik
{
    class GetTextFromKeyboardFabrik : BaseTextBlockFabrik
    {
        public GetTextFromKeyboardFabrik()
        {
            Text = "Отримати текст з клавіатури";
            Child = new TextBlock { Text = "Ввести текст", Foreground = Themes.MainColors.LightText, FontWeight = FontWeights.Bold };
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new GetTextFromKeyboard(container);
        }
    }
}
