using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourManAndRiver.Model
{
    /// <summary>
    /// 左岸
    /// </summary>
    public class LeftBank : Bank
    {
        public LeftBank()
        {
            men = new List<Man>()
            {
                Man.A,
                Man.B,
                Man.C,
                Man.D
            };

            dir = Direction.Left;
        }
    }
}
