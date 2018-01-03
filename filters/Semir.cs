using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Чапыгин_Фильтры
{
    class Semir : Filters
    {
        double kr;
        double kg;
        double kb;

        public Semir() { }

        protected void c(Bitmap s)
        {
            double k = 0;
            int n = s.Width * s.Height;
            for (int i = 0; i < s.Width; i++)
                for (int j = 0; j < s.Height; j++)
                {
                    kr += s.GetPixel(i, j).R;
                    kg += s.GetPixel(i, j).G;
                    kb += s.GetPixel(i, j).B;
                }
            kr /= n; kg /= n; kb /= n;
            k = (kr + kg + kb) / 3;
            this.kr = k / kr; this.kg = k / kg; this.kb = k / kb;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap b = new Bitmap(sourceImage.Width, sourceImage.Height);
            c(sourceImage);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                    b.SetPixel(i, j, Color.FromArgb(((int)(kr * sourceImage.GetPixel(i, j).R)), (int)(kg * sourceImage.GetPixel(i, j).G),(int)(kb * sourceImage.GetPixel(i, j).B)));
            }
            return b;
        }
    }
}
