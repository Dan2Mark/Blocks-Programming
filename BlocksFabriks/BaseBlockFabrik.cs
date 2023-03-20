using Blocks_Programming.Bloks;
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

namespace Blocks_Programming.Blocks_Fabriks
{
    class BaseBlockFabrik : Border
    {
        protected string Text { set { ToolTip = value;} }
        public BaseBlockFabrik()
        {
            HorizontalAlignment = HorizontalAlignment.Center;
            MinWidth = 100;
            MouseMove += BlockMove;
            MinHeight = 20;
            Margin = new Thickness(0, 5, 0, 5);
            Padding = new Thickness(3);
            Effect = new DropShadowEffect
            {
                Color = new Color { A = 255, R = 0, G = 0, B = 0 },
                Direction = 230,
                ShadowDepth = 2,
                Opacity = 0.25,
                BlurRadius = 5,
            };
            CornerRadius = new CornerRadius(5);
        }
        void BlockMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed &&
                sender is BaseBlockFabrik block)
            {
                DragDrop.DoDragDrop((BaseBlockFabrik)sender, new DataObject(DataFormats.Serializable,sender), DragDropEffects.Move);
            }
        }
        virtual public BaseBlock Create()
        {
            return new BaseBlock();
        }
    }
}
