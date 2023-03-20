using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik;
using Blocks_Programming.Bloks;
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
    class NumberFabrik : BaseNumberBlockFabrik
    {
        public NumberFabrik ()
        {
            Background = Themes.MainColors.Number;
            Child = new TextBox { IsEnabled = false, Text = "0.0", Background = Themes.MainColors.Number };
            Text = "Число";
            MinWidth = 35;
            Padding = new Thickness(2);
        }
        override public BaseBlock Create(BaseBlock container)
        {
            return new Number(container);
        }
        
    }
}
