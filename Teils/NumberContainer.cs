using Blocks_Programming.Blocks.ReturnBlock.Number;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik;
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
    class NumberContainer : Container
    {
        
        public NumberContainer (BaseBlock container, bool isEnable = true) : base (container)
        {
            Background = Themes.MainColors.ChangeSaturation(Themes.MainColors.ChangeBright(Themes.MainColors.Number, 20), 0.8);
            CornerRadius = new CornerRadius(5);
            if (isEnable)
            {
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.5, ShadowDepth = 0 };
                AllowDrop = true;
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 30);
            }
            else
            {
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.3, ShadowDepth = 0 };
            }
            Drop += DropBlock;
            DragEnter += EnterBlock;
            DragLeave += LeaveBlock;
        }

        static public NumberContainer getContainer()
        {
            return new NumberContainer(new BaseBlock());
        }

        protected void DropBlock(object sender, DragEventArgs e)
        {
            SetNewObjectView();
            var newNextBlock = e.Data.GetData(DataFormats.Serializable) as BaseBlock;

            if (newNextBlock != null)
            {
                newNextBlock.Opacity = 1;
            }

            if (newNextBlock != null && newNextBlock is BaseNumberBlock && Child == null && newNextBlock != this.container)
            {
                var newNumberBlock = (BaseNumberBlock)newNextBlock;
                if (newNumberBlock.container is Container)
                    ((Container)newNumberBlock.container).Child = null;
                newNumberBlock.container = this;
                Child = newNextBlock;
            }
            var fabrik = e.Data.GetData(DataFormats.Serializable) as BaseBlockFabrik;
            if (fabrik != null && fabrik is BaseNumberBlockFabrik && Child == null)
            {
                Child = ((BaseNumberBlockFabrik)fabrik).Create(this);            }
            }
        protected void EnterBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseNumberBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseNumberBlockFabrik;


            if (baseCB != null || baseCBF != null)
            {
                SetNewObjectView(true);
            }
        }
        protected void LeaveBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseNumberBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseNumberBlockFabrik;
            if (baseCB != null || baseCBF != null)
                SetNewObjectView();
        }
        private void SetNewObjectView(bool onOff = false)
        {
            if (onOff)
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 40);
            }
            else
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 20);
            }
        }
        public override bool IsRight()
        {
            if (Child != null)
                if (((BaseNumberBlock)Child).IsRight())
                {
                    Background = Themes.MainColors.ChangeBright(Themes.MainColors.Number, 10);
                    return true;
                }

            Background = Themes.MainColors.ChangeBright(new SolidColorBrush(Colors.Red), 70);
            return false;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            if (Child != null)
                return ((BaseNumberBlock)Child).GetC_SharpCode(c, i);
            return "";
        }
    }
}
