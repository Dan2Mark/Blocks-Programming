using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Blocks_Programming.Blocks.ReturnBlock.Text;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik
{
    class TextBlockFabrik : BaseTextBlockFabrik
    {
        public TextBlockFabrik ()
        {
            Child = new TextBox { IsEnabled = false,  Text = "Текст"};
            Padding = new System.Windows.Thickness(2);
            MinWidth = 50;
            Text = "Текст";
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new Text(container);
        }
    }
}
