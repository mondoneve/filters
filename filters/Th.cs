using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Чапыгин_Фильтры
{
    class Th : Matmorf
    {
        public Th() : base() { }
        public Th(bool[,] m) : base(m) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap o = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap r = new Bitmap(sourceImage.Width, sourceImage.Height);
            int rx = maska.GetLength(0) / 2;
            int ry = maska.GetLength(1) / 2;
            int w = sourceImage.Width;
            int h = sourceImage.Height;

            for (int y = ry; y < h - ry; y++)
            {
                worker.ReportProgress((int)((float)y / sourceImage.Height * 50));
                if (worker.CancellationPending) return null;
                for (int x = rx; x < w - rx; x++)
                {
                    int mr = sourceImage.GetPixel(x, y).R;
                    int mg = sourceImage.GetPixel(x, y).G;
                    int mb = sourceImage.GetPixel(x, y).B;
                    int k = 0;
                    for (int j = -ry; j <= ry; j++)
                    {
                        int l = 0;
                        for (int i = -rx; i <= rx; i++)
                        {
                            if (maska[l, k])
                            {
                                if (sourceImage.GetPixel(x + i, y + j).R > mr) mr = sourceImage.GetPixel(x + i, y + j).R;
                                if (sourceImage.GetPixel(x + i, y + j).G > mg) mg = sourceImage.GetPixel(x + i, y + j).G;
                                if (sourceImage.GetPixel(x + i, y + j).B > mb) mb = sourceImage.GetPixel(x + i, y + j).B;
                            }
                            l++;
                        }
                        k++;
                    }
                    o.SetPixel(x, y, Color.FromArgb(mr, mg, mb));
                }
            }
            for (int i = 0; i < w; i++) {
                worker.ReportProgress(50+(int)((float)i / sourceImage.Width * 50));
                if (worker.CancellationPending) return null;
                for (int j = 0; j < h; j++)
                    r.SetPixel(i, j, Color.FromArgb(Clamp(-(sourceImage.GetPixel(i, j).R - o.GetPixel(i, j).R), 0, 255), Clamp(-(sourceImage.GetPixel(i, j).G - o.GetPixel(i, j).G), 0, 255), Clamp(-(sourceImage.GetPixel(i, j).B - o.GetPixel(i, j).B), 0, 255)));
            }
            return r;
        }
    }
}
