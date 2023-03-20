using Blocks_Programming.BlocksFabriks.CommandBlockFabrik;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Blocks_Programming.Blocks.CommandBlock
{
    class BaseCommandBlock : BaseBlock 
    {
        static public bool canDrag = true;
        public BaseCommandBlock nextBlock = null;
        public BaseCommandBlock prevBlock = null;
        protected StackPanel elements = new StackPanel { Orientation = Orientation.Vertical};
        protected readonly int id = new Random().Next();
        public int index { get { return indexer; } set { indexer = value;} }
        private int indexer;
        Border dropPart = null;
        public BaseCommandBlock(FrameworkElement container, int indx = 0) : base ()
        {
            SetNewBaseValue(indx, container);
            //            HorizontalAlignment = HorizontalAlignment.Center;
            Margin = new Thickness(2);
            dropPart = new Border {
                Child = new TextBlock {
                    Text = "🡃",
                    Foreground = new SolidColorBrush(Color.FromRgb(220, 220, 220)),
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                Background = new LinearGradientBrush(Color.FromArgb(0, 0, 0, 0), Color.FromArgb(20, 0, 0, 0), 90), 
                Height = 13,
                AllowDrop = true
            };
            Child = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Children =
                {
                    new Border
                    {
                        Child = elements,
                        Padding = new Thickness(5, 5, 5, 0)
                    },
                    dropPart
                }
            };
           // MouseEnter += printData;
            MouseLeave += mouseLeave;
            MouseMove += BlockMove;
            dropPart.Drop += DropBlock;
            dropPart.DragEnter += EnterBlock;
            dropPart.DragLeave += LeaveBlock;
        }
        public void SetNewBaseValue(int indx, FrameworkElement container)
        {
            index = indx;
            SetContainer(container);
        }
        private void SetContainer(FrameworkElement elem)
        {
            if (container is StackPanel)
                ((StackPanel)container).Children.Remove(this);
            if (container is Border)
                ((Border)container).Child = null;
            if (elem is StackPanel)
            {
                ((StackPanel)elem).Children.Insert(index, this);
                container = elem;
            }
            else if (elem is Border)
            {
                
                ((Border)elem).Child = this;
                container = elem;
            }
        }
        void BlockMove(object sender, MouseEventArgs e)
        {
            if (canDrag && e.LeftButton == MouseButtonState.Pressed && sender as BaseBlock != null && this as Blocks.Start == null)
            {
                ((BaseCommandBlock)sender).Opacity = 0.6;
                DragDrop.DoDragDrop((BaseCommandBlock)sender, new DataObject(DataFormats.Serializable, sender), DragDropEffects.Move);
                ((BaseCommandBlock)sender).Opacity = 1;
            }
        }
        protected void EnterBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            if (baseCB != null)
                if (baseCB.TestOfCycleBlock(this) || baseCB == this || baseCB == nextBlock)
                {
                    dropPart.AllowDrop = false;
                    return;
                }
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if (baseCB != null || baseCBF != null)
            {
                SetNewObjectView(true);
            }
        }
        protected void LeaveBlock(object sender, DragEventArgs e)
        {
            var baseCB = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            var baseCBF = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if (baseCB != null || baseCBF != null)
            {
                SetNewObjectView();
            }
        }
        protected void DropBlock(object sender, DragEventArgs e)
        {
            SetNewObjectView();
            var newNextBlock = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlock;
            if (newNextBlock != null)
            {
                newNextBlock.Opacity = 1;
            }
                if (newNextBlock != null && newNextBlock != this && newNextBlock != nextBlock)
            {
                if (newNextBlock.nextBlock != null)
                {
                    newNextBlock.nextBlock.prevBlock = newNextBlock.prevBlock;
                    changeNextBlockIndex(newNextBlock.nextBlock, -1);
                }
                if (nextBlock != null)
                {
                    nextBlock.prevBlock = newNextBlock;
                    changeNextBlockIndex(nextBlock, 1);
                }
                if (newNextBlock.prevBlock != null)
                {
                    newNextBlock.prevBlock.nextBlock = newNextBlock.nextBlock;
                }
                newNextBlock.prevBlock = this;
                newNextBlock.nextBlock = nextBlock;
                nextBlock = newNextBlock;
                ((BaseCommandBlock)nextBlock).SetNewBaseValue(index + 1, container);
            }
            var fabrik = e.Data.GetData(DataFormats.Serializable) as BaseCommandBlockFabrik;
            if (fabrik != null)
            {
                newNextBlock = (BaseCommandBlock)fabrik.Create(container, index + 1);
                if (nextBlock != null)
                {
                    changeNextBlockIndex(nextBlock, 1);
                    nextBlock.prevBlock = newNextBlock;
                    newNextBlock.nextBlock = nextBlock;
                }
                newNextBlock.prevBlock = this;
                nextBlock = newNextBlock;
            }
        }

        protected void mouseLeave(object sender, EventArgs e)
        {
            dropPart.AllowDrop = true;
        }
        private void changeNextBlockIndex(BaseCommandBlock block, int change)
        {
            block.index += change;
            if (block.nextBlock != null)
            {
                changeNextBlockIndex(block.nextBlock, change);
            }
        }
        
        private void SetNewObjectView (bool onOff = false)
        {
            if (onOff)
            {
                if (nextBlock != null)
                nextBlock.Margin = new Thickness(3, 20, 3, 2);
                ((TextBlock)dropPart.Child).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                if (nextBlock != null)
                    nextBlock.Margin = new Thickness(3, 2, 3, 2);
                ((TextBlock)dropPart.Child).Foreground = new SolidColorBrush(Color.FromRgb(230, 230, 235));
            }
        }
        /*
        public void printData (object sender, EventArgs e)
        {
            ToolTip = $"id {id}\n" +
                $"{index}\n" +
                $"prev {prevBlock?.id}\n" +
                $"next {nextBlock?.id}";
        }*/

        protected  virtual void Command()
        {

        }
        public void DoCommand()
        {
            Command();
            if (nextBlock != null)
                nextBlock.DoCommand();
        }
        virtual public bool TestOfCycleBlock (BaseCommandBlock sender)
        {
            return false;
        }
        public override void Delete()
        {
            if (container is StackPanel)
                ((StackPanel)container).Children.Remove(this);
            if (container is Border)
                ((Border)container).Child = null;
            if (nextBlock != null)
            {
                nextBlock.prevBlock = prevBlock;
                nextBlock.changeNextBlockIndex(nextBlock, -1);
            }
            if (prevBlock != null)
                prevBlock.nextBlock = nextBlock;
        }
        public override bool IsRight()
        {
            if (nextBlock != null)
                if (!nextBlock.IsRight())
                    return false;
            return true;
        }
        public string GetChildrenCode(int c, int i, GroupBlock children)
        {
            string childrenCode = "";
            foreach (var child in children.childrenContainer.Children)
            {
                childrenCode += "\n" + ((BaseCommandBlock)child).GetC_SharpCode(c,i);
            }
            return childrenCode;
        }
    }
}
