using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourManAndRiver.Model
{
    /// <summary>
    /// 右岸
    /// </summary>
    public class RightBank : Bank
    {
        public RightBank()
        {
            men = new List<Man>();
            dir = Direction.Right;
        }
    }
}
