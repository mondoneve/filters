using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Чапыгин_Фильтры
{
    class Scharr : MatrixFilter
    {
        public Scharr()
        {
            kernel = new float[3, 3];
            kernel[0, 0] = 3.0f;
            kernel[1, 0] = 10.0f;
            kernel[2, 0] = 3.0f;
            kernel[0, 1] = 0.0f;
            kernel[1, 1] = 0.0f;
            kernel[2, 1] = 0.0f;
            kernel[0, 2] = -3.0f;
            kernel[1, 2] = -10.0f;
            kernel[2, 2] = -3.0f;
        }
    }
}
