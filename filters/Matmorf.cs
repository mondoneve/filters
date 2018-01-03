using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Чапыгин_Фильтры
{
    abstract class Matmorf : Filters
    {
        protected bool[,] maska = null;

        public Matmorf() { maska = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false } }; }
        public Matmorf(bool[,] m) { maska = m; }
    }
}
