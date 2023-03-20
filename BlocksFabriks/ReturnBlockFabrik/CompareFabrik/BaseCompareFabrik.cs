using Blocks_Programming.Blocks.ReturnBlock.Compare;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.CompareFabrik
{
    class BaseCompareFabrik : BaseReturnBlockFabrik
    {
        public BaseCompareFabrik()
        {
            Background = Themes.MainColors.Comporate;
        }
        public override BaseBlock Create(BaseBlock container)
        {
            return new BaseCompareBlock(container);
        }
    }
}
