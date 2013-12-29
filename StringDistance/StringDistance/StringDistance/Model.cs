using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringDistance
{
    public struct Model
    {
        public int c1;
        public int c2;
        public int distance { get { return c2 - c1; } }
    }
}
