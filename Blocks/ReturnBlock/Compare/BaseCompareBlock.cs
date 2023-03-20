using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Blocks_Programming.Blocks.ReturnBlock.Compare
{
    public class BaseCompareBlock : BaseReturnBlock 
    {
        public BaseCompareBlock(BaseBlock container) : base(container)
        {
            Background = Themes.MainColors.Comporate;
        }
        public bool getValue()
        {
            bool outstr = false; 
            outstr = GetValue();
            return outstr;
        }
        protected virtual bool GetValue()
        {
            return false;
        }
        public override bool IsRight()
        {
            return true;
        }
    }
}
