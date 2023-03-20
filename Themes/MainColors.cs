using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Blocks_Programming.Themes
{
    public class MainColors
    {
        public static SolidColorBrush Cycle { get { return new SolidColorBrush(Color.FromRgb(181, 230, 29)); } }
        public static SolidColorBrush Condition { get { return new SolidColorBrush(Color.FromRgb(255, 201, 14)); } }

        public static SolidColorBrush Number { get { return new SolidColorBrush(Color.FromRgb(173,204,255)); } }

        public static SolidColorBrush Print { get { return new SolidColorBrush(Color.FromRgb(255, 163, 199)); } }

        public static SolidColorBrush Text { get { return new SolidColorBrush(Color.FromRgb(225, 153, 255)); } }

        public static SolidColorBrush Comporate { get { return ChangeBright(new SolidColorBrush(Color.FromRgb(255, 127, 39)),30); } }
        public static SolidColorBrush DarkText { get { return new SolidColorBrush(Color.FromRgb(42, 45, 47)); } }

        public static SolidColorBrush LightText { get { return new SolidColorBrush(Color.FromRgb(240, 245, 255)); } }


        public static SolidColorBrush ChangeBright(Brush colorBrush, int strength)
        {
            return ChangeBright((SolidColorBrush)colorBrush, strength);
        }
            public static SolidColorBrush ChangeBright (SolidColorBrush colorBrush, int strength)
        {
            int r = colorBrush.Color.R, g = colorBrush.Color.G, b = colorBrush.Color.B, c = strength;
            
            return new SolidColorBrush(Color.FromRgb(ConvertToByte(r + c), ConvertToByte(g + c), ConvertToByte(b + c)));
        }
        public static SolidColorBrush ChangeSaturation(Brush colorBrush, double strength)
        {
            return ChangeSaturation((SolidColorBrush)colorBrush, strength);
        }

        public static SolidColorBrush ChangeSaturation(SolidColorBrush colorBrush, double strength)
        {
            if (colorBrush != null)
            {
                int r = colorBrush.Color.R, g = colorBrush.Color.G, b = colorBrush.Color.B;
                return new SolidColorBrush(Color.FromRgb(ConvertToByte(smooth(r, strength)), ConvertToByte(smooth(g, strength)), ConvertToByte(smooth(b, strength))));
            }
            return null;
        }
        static int smooth(int a, double b)
        {
            return (int)(a * b + b * 40);
        }
        static public byte ConvertToByte (float a)
        {
            int b = Convert.ToInt32(a);
            if (b < 0) b = 0;
            if (b > 255) b = 255;
            return (byte)b;
        }
    }
}
