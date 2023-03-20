using Blocks_Programming.Blocks.ReturnBlock;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik
{
    class BaseReturnBlockFabrik : BaseBlockFabrik
    {
        public virtual BaseBlock Create(BaseBlock container)
        {
            return new BaseReturnBlock(container);
        }
    }
}
