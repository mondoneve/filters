using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Чапыгин_Фильтры
{
    class Volny : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();
            int xx = Clamp((int)(x + 20 * Math.Sin(2 * Math.PI * y / 60)), 0, sourceImage.Width - 1);
            int yy = y;
            return Color.FromArgb(sourceImage.GetPixel(xx, yy).R, sourceImage.GetPixel(xx, yy).G, sourceImage.GetPixel(xx, yy).B);
        }
    }
}
