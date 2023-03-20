using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.BlocksFabriks.CommandBlockFabrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Blocks_Programming.Teils
{
    class GroupBlock : Border
    {
        public StackPanel childrenContainer = new StackPanel ();
        BaseCommandBlock container = null;
        bool isEnable;
        public GroupBlock (BaseCommandBlock container, bool isEnable = true)
        {
            this.container = container;
            this.isEnable = isEnable;
            Drop += DropBlock;
            Padding = new Thickness(1,2,1,2);
            DragEnter += EnterBlock;
            DragLeave += LeaveBlock;
            MouseLeave += mouseLeave;
            Background = new SolidColorBrush(Color.FromArgb(255, 240, 240, 230));
            Child = childrenContainer;
            MinHeight = 20;
            CornerRadius = new CornerRadius(4);
            if (isEnable)
            {
                AllowDrop = true;
                Background = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240));
            }

        }
        protected void DropBlock(object sender, DragEventArgs e)
        {
            SetNewObjectView();
            bool flag = true;
            var newNextBlock = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            BaseCommandBlock firstBlock = null;
            if (newNextBlock != null)
            {
                newNextBlock.Opacity = 1;
            }
            if (childrenContainer.Children.Count > 0)
                if (newNextBlock == childrenContainer.Children[0])
                {
                    flag = false;
                    firstBlock = childrenContainer.Children[0] as BaseCommandBlock;
                }

            if (newNextBlock != null && flag && childrenContainer.Children.Count < 1)
            {
                if (newNextBlock.nextBlock != null)
                {
                    newNextBlock.nextBlock.prevBlock = newNextBlock.prevBlock;
                    changeNextBlockIndex(newNextBlock.nextBlock, -1);
                }
                if (firstBlock != null)
                {
                    firstBlock.prevBlock = newNextBlock;
                    changeNextBlockIndex(firstBlock, 1);
                    firstBlock.SetNewBaseValue(1, childrenContainer);
                }
                if (newNextBlock.prevBlock != null)
                {
                newNextBlock.prevBlock.nextBlock = newNextBlock.nextBlock;
                }
                newNextBlock.nextBlock = firstBlock;
                newNextBlock.prevBlock = null;
                newNextBlock.SetNewBaseValue(0, childrenContainer);

            }
            var fabrik = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if (fabrik != null && childrenContainer.Children.Count < 1)
            {
                newNextBlock = (BaseCommandBlock)fabrik.Create(childrenContainer, 0);
                if (firstBlock != null)
                {
                    changeNextBlockIndex(firstBlock, 1);
                    firstBlock.prevBlock = newNextBlock;
                    newNextBlock.nextBlock = firstBlock;
                }
                newNextBlock.prevBlock = null;
            }
        }
        private void changeNextBlockIndex(BaseCommandBlock block, int change)
        {
            block.index += change;
            if (block.nextBlock != null)
            {
                changeNextBlockIndex(block.nextBlock, change);
            }
        }
        protected void EnterBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            if (baseCB != null)
            {
                if (baseCB == container || baseCB.TestOfCycleBlock(container))
                {
                    AllowDrop = false;
                    return;
                }
            }
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if ((baseCB != null || baseCBF != null) && childrenContainer.Children.Count < 1)
                SetNewObjectView(true);
        }
        protected void LeaveBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if (baseCB != null || baseCBF != null)
                SetNewObjectView();
        }
        protected void mouseLeave(object sender, EventArgs e)
        {
            if (isEnable)
            AllowDrop = true;
        }
            private void SetNewObjectView(bool onOff = false)
        {
            if (onOff)
            {
                Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                Background = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240));
            }
        }
    }
}
