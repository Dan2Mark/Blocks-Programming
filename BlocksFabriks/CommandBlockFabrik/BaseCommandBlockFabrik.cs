using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocks_Programming.BlocksFabriks.CommandBlockFabrik
{
    class BaseCommandBlockFabrik : BaseBlockFabrik
    {
        public virtual BaseBlock Create(FrameworkElement container, int indx = 0)
        {
            return new BaseCommandBlock(container,indx);
        }
    }
}
