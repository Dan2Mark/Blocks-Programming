using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocks_Programming.Teils
{
    public class Container : BaseBlock
    {
        public BaseBlock container = null;
        public Container(BaseBlock container)
        {
            this.container = container;
            Margin = new Thickness(2);
            MinHeight = 16;
            MinWidth = 26;
        }
        public virtual bool IsRight()
        {
            return true;
        }
    }
}
