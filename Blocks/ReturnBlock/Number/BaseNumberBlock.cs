using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Programming.Blocks.ReturnBlock.Number
{
    class BaseNumberBlock : BaseReturnBlock
    {
        public BaseNumberBlock (BaseBlock container) : base (container)
        {
            Background = Themes.MainColors.Number;
        }
        public double getValue()
        {
            double outstr = 0;
            outstr = GetValue();
            return outstr;
        }
        protected virtual double GetValue()
        {
            return 0;
        }
    }
}
