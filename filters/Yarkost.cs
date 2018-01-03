using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Чапыгин_Фильтры
{
    class Yarkost : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.FromArgb(Clamp(sourceImage.GetPixel(x, y).R + 50, 0, 255), Clamp(sourceImage.GetPixel(x, y).G + 50, 0, 255), Clamp(sourceImage.GetPixel(x, y).B + 50, 0, 255));
        }
    }
}
