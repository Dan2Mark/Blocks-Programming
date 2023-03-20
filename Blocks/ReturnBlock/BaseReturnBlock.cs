using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Bloks;
using Blocks_Programming.Teils;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocks_Programming.Blocks.ReturnBlock
{
    public class BaseReturnBlock : BaseBlock
    {
        public bool canDrag = true;
        public BaseBlock container = null;
        public BaseReturnBlock (BaseBlock container)
        {
            this.container = container;
            HorizontalAlignment = HorizontalAlignment.Center;
            MinWidth = 100;
            MouseEnter += mouseEnter;
            MouseLeave += mouseLeave;
            MouseMove += BlockMove;
            
            Padding = new Thickness(2);
        }
        protected virtual void BlockMove(object sender, MouseEventArgs e)
        {
            if (canDrag && e.LeftButton == MouseButtonState.Pressed && sender as BaseReturnBlock != null)
            {
                ((BaseReturnBlock)sender).Opacity = 0.6;
                DragDrop.DoDragDrop((BaseBlock)sender, new DataObject(DataFormats.Serializable, sender), DragDropEffects.Move);
                ((BaseReturnBlock)sender).Opacity = 1;
            }
        }

            void mouseEnter(object sender, EventArgs e)
        {
            var mainContainer = container;
            if (mainContainer is Container)
                mainContainer = ((Container)mainContainer).container;
            if (mainContainer is BaseCommandBlock)
                BaseCommandBlock.canDrag = false;
            if (mainContainer is BaseReturnBlock)
                ((BaseReturnBlock)mainContainer).canDrag = false;
        }
        void mouseLeave(object sender, EventArgs e)
        {
            var mainContainer = container;
            if (mainContainer is Container)
                mainContainer = ((Container)mainContainer).container;
            if (mainContainer is BaseCommandBlock)
                BaseCommandBlock.canDrag = true;
            if (mainContainer is BaseReturnBlock)
                ((BaseReturnBlock)mainContainer).canDrag = true;
        }

        public override void Delete()
        {
            container.Child = null;
        }
    }
}
