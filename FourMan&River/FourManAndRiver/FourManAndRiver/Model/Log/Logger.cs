using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourManAndRiver.Model.Log
{
    /// <summary>
    /// 状态树
    /// </summary>
    public class Logger : ICloneable
    {
        struct Status
        {
            public Man man1;
            public Man man2;
            public Direction dir;
        }

        #region Property
        /// <summary>
        /// 状态树记录List
        /// </summary>
        private IList<Status> sList = new List<Status>();

        private int value = 0;
        /// <summary>
        /// 总用时
        /// </summary>
        public int Sum
        {
            get { return value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 记录当前状态
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="dir"></param>
        public void Log(Man m1, Man m2, Direction dir)
        {
            sList.Add(new Status() { man1 = m1, man2 = m2, dir = dir });
            value += m1 > m2 ? (int)m1 : (int)m2;
        }

        /// <summary>
        /// 返回上一级状态
        /// </summary>
        public void back()
        {
            Status s = sList.Last();
            value -= s.man1 > s.man2 ? (int)s.man1 : (int)s.man2;

            sList.RemoveAt(sList.Count() - 1);
        }

        /// <summary>
        /// 打印当前状态树结果
        /// </summary>
        public void ConsoleLog()
        {
            Console.WriteLine("---------------------Begin-----------------------------");
            foreach (var s in sList)
            {
                if (s.man2 != Man.Empty)
                {
                    Console.Write(s.man1.ToString() + "," + s.man2.ToString() + "过桥,用时" + (s.man1 > s.man2 ? (int)s.man1 : (int)s.man2) + "分钟。");
                }
                else
                {
                    Console.WriteLine(s.man1.ToString() + "返回,用时" + (int)s.man1 + "分钟。");
                }
            }
            Console.WriteLine("共用时:" + Sum + "分钟");
            Console.WriteLine("---------------------End-----------------------------");
            Console.WriteLine("");
        }
        #endregion       

        #region IClonable
        /// <summary>
        /// 返回当前状态树的克隆
        /// 用于保存当前状态
        /// （深克隆）
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Logger clone = (Logger)this.MemberwiseClone();

            clone.sList = new List<Status>();
            foreach (var s in this.sList)
            {
                clone.sList.Add(s);
            }

            return clone;
        }
        #endregion
    }
}
