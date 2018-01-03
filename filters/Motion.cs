using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Чапыгин_Фильтры
{
    class Motion : MatrixFilter
    {
        public Motion()
        {
            kernel = new float[9, 9];
            for (int i = 0; i < 9; i++) for (int j = 0; j < 9; j++) kernel[i, j] = (i==j)? 0.1f : 0.0f;
        }
    }
}
