using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Чапыгин_Фильтры
{
    class Sobel : MatrixFilter
    {
        public Sobel()
        {
            kernel = new float[3, 3];
            kernel[0,0] = -1.0f;
            kernel[1, 0] = -2.0f;
            kernel[2, 0] = -1.0f;
            kernel[0, 1] = 0.0f;
            kernel[1, 1] = 0.0f;
            kernel[2, 1] = 0.0f;
            kernel[0, 2] = 1.0f;
            kernel[1, 2] = 2.0f;
            kernel[2, 2] = 1.0f;
        }
    }
}
