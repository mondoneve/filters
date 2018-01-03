using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

namespace Чапыгин_Фильтры
{
    class Median : Filters
    {
        int[] m;
        int rx = 0;
        int ry = 0;
        public Median() { rx = 3; ry = 3; m = new int[9]; }
        public Median(int x, int y) { rx = x;ry = y; m = new int[rx*ry]; }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int rrx = rx / 2;
            int rry = ry / 2;
            int v = 0;
            int z = 0;
            for (int i = - rrx; i <= rrx; i++ )
                for (int j = - rry; j<=rry;j++)
                {
                    int xx = Clamp(x + i, 0, sourceImage.Width - 1);
                    int yy = Clamp(y + j, 0, sourceImage.Height - 1);
                    int ya = (int)((sourceImage.GetPixel(xx, yy).R + sourceImage.GetPixel(xx, yy).G + sourceImage.GetPixel(xx, yy).B) / 3);
                    m[z] = ya; z++;
                }
            Array.Sort(m);
            v = m[rx*ry/2];
            return Color.FromArgb(v, v, v);
        }
    }
}
