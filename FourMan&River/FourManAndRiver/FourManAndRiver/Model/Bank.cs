using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourManAndRiver.Model
{
    /// <summary>
    /// 河岸
    /// </summary>
    public class Bank
    {
        #region Filed
        /// <summary>
        /// 人数
        /// </summary>
        public IList<Man> men;
        /// <summary>
        /// 代表的方向
        /// </summary>
        public Direction dir;
        #endregion

    }
}
