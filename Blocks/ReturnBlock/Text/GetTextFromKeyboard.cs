using Blocks_Programming.Bloks;
using Blocks_Programming.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Blocks_Programming.Blocks.ReturnBlock.Text
{
    class GetTextFromKeyboard : BaseTextBlock
    {
        public GetTextFromKeyboard (BaseBlock container) : base (container)
        {
            Child = new TextBlock { Text = "Ввести текст", Padding = new System.Windows.Thickness(2), Foreground = Themes.MainColors.LightText, FontWeight = FontWeights.Bold };
        }
        protected override string GetValue()
        {
            string outstr = "";
            outstr = console.GetText();
            return outstr;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            return $"Console.ReadLine()";
        }
    }
}
