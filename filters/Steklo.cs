using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Чапыгин_Фильтры
{
    class Steklo : Filters
    {
        Random rand = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int xx = Clamp((int)(x + 10 * (rand.NextDouble() - 0.5f)),0,sourceImage.Width-1);
            int yy = Clamp((int)(y + 10 * (rand.NextDouble() - 0.5f)),0,sourceImage.Height-1);
            return Color.FromArgb(sourceImage.GetPixel(xx, yy).R, sourceImage.GetPixel(xx, yy).G, sourceImage.GetPixel(xx, yy).B);
        }
    }
}
