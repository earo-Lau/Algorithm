using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourManAndRiver.Model.Log;

namespace FourManAndRiver.Model
{
    /// <summary>
    /// 手电筒
    /// </summary>
    public class Flashlight
    {
        #region Filed
        /// <summary>
        /// 手电筒所在的位置
        /// </summary>
        public Direction _dir;
        #endregion

        #region Constructor
        public Flashlight()
        {
            _dir = Direction.Left;
        }
        #endregion

        #region Method
        /// <summary>
        /// 过河
        /// </summary>
        /// <param name="to">移动目标</param>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="log"></param>
        /// <param name="callback"></param>
        public void Trans(Bank to, Man m1, Man m2, Logger log, Callback callback)
        {
            to.men.Add(m1);
            if (m2 != Man.Empty)
            {
                to.men.Add(m2);
            }
            log.Log(m1, m2, _dir);

            _dir = to.dir;
            if (callback != null)
            {
                callback.Invoke();
            }
        }
        #endregion]
    }
}
