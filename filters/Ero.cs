using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Чапыгин_Фильтры
{
    class Ero : Matmorf
    {
        public Ero() : base() { }
        public Ero(bool[,] m) : base(m) { }


        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap r = new Bitmap(sourceImage.Width, sourceImage.Height);
            int rx = maska.GetLength(0) / 2;
            int ry = maska.GetLength(1) / 2;
            int w = sourceImage.Width;
            int h = sourceImage.Height;

            for (int y = ry; y < h - ry; y++)
            {
                worker.ReportProgress((int)((float)y / sourceImage.Width * 100));
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
                                if (sourceImage.GetPixel(x + i, y + j).R < mr) mr = sourceImage.GetPixel(x + i, y + j).R;
                                if (sourceImage.GetPixel(x + i, y + j).G < mg) mg = sourceImage.GetPixel(x + i, y + j).G;
                                if (sourceImage.GetPixel(x + i, y + j).B < mb) mb = sourceImage.GetPixel(x + i, y + j).B;
                            }
                            l++;
                        }
                        k++;
                    }
                    r.SetPixel(x, y, Color.FromArgb(mr, mg, mb));
                }
            }
            return r;
        }
    }
}
