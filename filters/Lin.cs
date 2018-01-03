using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Чапыгин_Фильтры
{
    class Lin : Filters
    {

        protected int l(int x, int mm, int m)
        {
            return (int)((x - m) * 255 / (mm - m));
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int r = sourceImage.GetPixel(0,0).R; int rr = r; int g = sourceImage.GetPixel(0, 0).G; int gg = g; int b = sourceImage.GetPixel(0, 0).B; int bb = b;
            int w = sourceImage.Width;
            int h = sourceImage.Height;
            Bitmap o = new Bitmap(w, h);
            for (int i = 0; i < w; i++) for (int j = 0; j < h; j++)
                {
                    if (sourceImage.GetPixel(i, j).R > rr) rr = sourceImage.GetPixel(i, j).R;
                    if (sourceImage.GetPixel(i, j).R < r) r = sourceImage.GetPixel(i, j).R;
                    if (sourceImage.GetPixel(i, j).G > gg) gg = sourceImage.GetPixel(i, j).G;
                    if (sourceImage.GetPixel(i, j).G < g) g = sourceImage.GetPixel(i, j).G;
                    if (sourceImage.GetPixel(i, j).B > bb) bb = sourceImage.GetPixel(i, j).B;
                    if (sourceImage.GetPixel(i, j).B < b) b = sourceImage.GetPixel(i, j).B;
                }
            for (int i = 0; i < w; i++)
            {
                worker.ReportProgress((int)((float)i / w * 100));
                if (worker.CancellationPending) return null;
                for (int j = 0; j < h; j++) o.SetPixel(i, j, Color.FromArgb(l(sourceImage.GetPixel(i, j).R, rr, r), l(sourceImage.GetPixel(i, j).G, gg, g), l(sourceImage.GetPixel(i, j).B, bb, b)));
            }
            return o;
        }
    }
}
