using Blocks_Programming.Blocks.ReturnBlock.Text;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Blocks_Programming.Teils
{
    class TextContainer : Container
    {
        public TextContainer(BaseBlock container, bool isEnable = true) : base(container)
        {
            Background = Themes.MainColors.ChangeSaturation(Themes.MainColors.ChangeBright(Themes.MainColors.Text, 30), 0.7);
            Background = Themes.MainColors.Text;
            CornerRadius = new CornerRadius(5);
            if (isEnable)
            {
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.5, ShadowDepth = 0 }; 
                AllowDrop = true;
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Text, 40);
            }
            else
            {
                Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 2, Opacity = 0.3, ShadowDepth = 0 };
            }
            Drop += DropBlock;
            DragEnter += EnterBlock;
            DragLeave += LeaveBlock;
        }
        protected void DropBlock(object sender, DragEventArgs e)
        {
            SetNewObjectView();
            var newNextBlock = e.Data.GetData(DataFormats.Serializable) as BaseBlock;

            if (newNextBlock != null)
            {
                newNextBlock.Opacity = 1;
            }
            if (newNextBlock != null && newNextBlock is BaseTextBlock && Child == null && newNextBlock != this.container)
            {
                var newNumberBlock = (BaseTextBlock)newNextBlock;
                if (newNumberBlock.container is Container)
                    ((Container)newNumberBlock.container).Child = null;
                newNumberBlock.container = this;
                Child = newNextBlock;
            }
            var fabrik = e.Data.GetData(DataFormats.Serializable) as BaseBlockFabrik;
            if (fabrik != null && fabrik is BaseTextBlockFabrik && Child == null)
            {
                Child = ((BaseTextBlockFabrik)fabrik).Create(this);
            }
        }
        protected void EnterBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseTextBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseTextBlockFabrik;


            if (baseCB != null || baseCBF != null)
            {
                SetNewObjectView(true);
            }
        }
        protected void LeaveBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseTextBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseTextBlockFabrik;
            if (baseCB != null || baseCBF != null)
                SetNewObjectView();
        }
        private void SetNewObjectView(bool onOff = false)
        {
            if (onOff)
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Text, 60);
            }
            else
            {
                Background = Themes.MainColors.ChangeBright(Themes.MainColors.Text, 40);
            }
        }

        public override bool IsRight()
        {   
            if (Child != null)
                if (((BaseTextBlock)Child).IsRight())
                {
                    Background = Themes.MainColors.ChangeBright(Themes.MainColors.Text, 10);
                    return true;
                }

            Background = Themes.MainColors.ChangeBright(new SolidColorBrush(Colors.Red), 70);
            return false;
        }
        public override string GetC_SharpCode(int c, int i)
        {
            if (Child != null)
                return ((BaseTextBlock)Child).GetC_SharpCode(c, i);
            return "";
        }
    }
}
