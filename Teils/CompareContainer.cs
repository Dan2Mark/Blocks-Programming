using Blocks_Programming.Blocks.ReturnBlock.Compare;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.CompareFabrik;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Blocks_Programming.Teils
{
    public class CompareContainer : Container
    {
        bool isEnable;
        public CompareContainer (BaseBlock container, bool isEnable = true) : base (container)
        {
            this.isEnable = isEnable;
            Background = Themes.MainColors.ChangeBright(Themes.MainColors.ChangeSaturation(Themes.MainColors.Comporate, 0.7), 30);
            CornerRadius = new CornerRadius(5);
            Drop += DropBlock;
            DragEnter += EnterBlock;
            DragLeave += LeaveBlock;

            if (isEnable)
            {
                AllowDrop = true;
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Comporate, 10);
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.5, ShadowDepth = 0 };
            }
            else
            {
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.3, ShadowDepth = 0 };
            }
        }

        public void SetChild(BaseCompareBlock newNextBlock)
        {
            Child = newNextBlock;
        }
        protected void DropBlock(object sender, DragEventArgs e)
        {
            SetNewObjectView();
            var newNextBlock = e.Data.GetData(DataFormats.Serializable) as BaseBlock;

            if (newNextBlock != null)
            {
                newNextBlock.Opacity = 1;
            }

            if (newNextBlock != null && newNextBlock is BaseCompareBlock && Child == null && newNextBlock != this.container)
            {
                var newNumberBlock = (BaseCompareBlock)newNextBlock;
                if (newNumberBlock.container is Container)
                    ((Container)newNumberBlock.container).Child = null;
                newNumberBlock.container = this;
                Child = newNextBlock;
            }
            var fabrik = e.Data.GetData(DataFormats.Serializable) as BaseBlockFabrik;
            if (fabrik != null && fabrik is BaseCompareFabrik && Child == null)
            {
                Child = ((BaseCompareFabrik)fabrik).Create(this);            }
            }
        protected void EnterBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCompareBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCompareFabrik;
            if (baseCB != null || baseCBF != null)
                SetNewObjectView(true);
        }
        protected void LeaveBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCompareBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCompareFabrik;
            if (baseCB != null || baseCBF != null)
                SetNewObjectView();
        }
        private void SetNewObjectView(bool onOff = false)
        {
            if (onOff)
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Comporate, 30);
            }
            else
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Comporate, 10);
            }
        }
        public override bool IsRight()
        {
            if (Child != null)
                if (((BaseCompareBlock)Child).IsRight())
                {
                    Background = Themes.MainColors.ChangeBright(Themes.MainColors.Comporate, 10);
                    return true;
                }

            Background = Themes.MainColors.ChangeBright(new SolidColorBrush(Colors.Red), 70);
            return false;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            if (Child != null)
                return ((BaseCompareBlock)Child).GetC_SharpCode(c, i);
            return "";
        }
    }
}
