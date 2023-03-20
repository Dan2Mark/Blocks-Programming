using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Programming.Blocks.ReturnBlock.Text
{
    class BaseTextBlock : BaseReturnBlock
    {
        public BaseTextBlock(BaseBlock container) : base(container)
        {
            Background = Themes.MainColors.Text;
        }
        public string getValue()
        {
            string outstr = "";
            outstr = GetValue();
            // Dispatcher.Invoke(() => { outstr = GetValue(); });
            return outstr;
        }
        protected virtual string GetValue()
        {
            return "";
        }
    }
}
