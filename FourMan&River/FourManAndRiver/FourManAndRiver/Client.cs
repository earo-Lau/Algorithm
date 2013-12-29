/**
 * 四人过河问题：
 * 有甲乙丙丁四人在晚上过桥，桥一次只能走两人，而且要用手电筒，手电筒只有一只，
 * 四人过的速度为：甲1分钟，乙2分钟，丙5分钟，丁10分钟。走的快的要等走的慢的。
 * 请问他们如何应如何使过河时间最短？请用编程的方法求出结果。
 * 
 * 解决思路：
 * 首先分析对象模型：我们有四人，在左岸，通过手电筒，到达右岸。
 * 因此我们可以定义状态为一个包含有左岸人数，右岸人数，手电筒位置的三元数组。即(左岸人数，右岸人数，手电筒位置)
 * 那么起始的状态为(4, 0, 0)，而终止的状态为(0, 4, 1)
 * 因为每次我们的动作都是左边过两人，右边回来一人。一次每种过桥方法的动作次数是一定的
 * 即(4, 0, 0)-->(2, 2, 1)-->(3, 1, 0)-->(1, 3, 1)-->(2, 2, 0)-->(0, 4, 1)
 * 只是每次动作的时间不一样而已。
 * 
 * 因此本人考虑用穷举法来穷举出所有的过桥方法。建立状态树来对所有的结果选择最优解。
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FourManAndRiver.Model;
using FourManAndRiver.Model.Log;

namespace FourManAndRiver
{
    /// <summary>
    /// 动作委托
    /// </summary>
    public delegate void Callback();
    
    public class Client
    {
        #region Obj_Model
        /// <summary>
        /// 左岸
        /// </summary>
        private Bank _left;
        /// <summary>
        /// 右岸
        /// </summary>
        private Bank _right;
        /// <summary>
        /// 手电筒
        /// </summary>
        private Flashlight _light;
        /// <summary>
        /// 状态树
        /// </summary>
        private Logger _log = new Logger();
        /// <summary>
        /// 最优解
        /// </summary>
        private Logger _best;
        #endregion

        #region Filed
        /// <summary>
        /// 记录过河方法次数
        /// </summary>
        private int count = 0;
        #endregion

        #region Construction
        /// <summary>
        /// 初始化对象
        /// </summary>
        public Client()
        {
            _left = new Bank()
            {
                men = new List<Man>() { Man.A, Man.B, Man.C, Man.D },
                dir = Direction.Left
            };
            _right = new Bank()
            {
                men = new List<Man>(),
                dir = Direction.Right
            };
            _light = new Flashlight();
        }
        #endregion

        #region Actions
        /// <summary>
        /// 从左岸移动两个人
        /// </summary>
        public void LeftMove()
        {
            if (2 < _left.men.Count())
            {
                //遍历移动两个人
                for (int i = 0; i < _left.men.Count(); i++)
                {
                    for (int j = i + 1; j < _left.men.Count(); j++)
                    {
                        //获取要移动的人
                        var temp_i = _left.men[i];
                        var temp_j = _left.men[j];
                        _left.men.Remove(temp_i);
                        _left.men.Remove(temp_j);

                        _light.Trans(_right, temp_i, temp_j, _log, RightMove);
                        //移动完成，返回状态树的上一级
                        _log.back();

                        _left.men.Insert(i, temp_i);
                        _left.men.Insert(j, temp_j);
                        _right.men.Remove(temp_i);
                        _right.men.Remove(temp_j);
                    }
                }
            }
            else
            {
                //最后一次移动
                _light.Trans(_right, _left.men[0], _left.men[1], _log, null);
                Console.WriteLine("第" + ++count + "种过桥方法：");
                _log.ConsoleLog();
                if (count == 1 || _log.Sum < _best.Sum)
                {
                    _best = (Logger)_log.Clone();
                }

                //移动完成，返回状态树的上一级
                _log.back();
                _right.men.Remove(_left.men[0]);
                _right.men.Remove(_left.men[1]);
            }
        }

        /// <summary>
        /// 从右岸返回一个人
        /// </summary>
        public void RightMove()
        {
            for (int i = 0; i < _right.men.Count(); i++)
            {
                var temp_i = _right.men[i];
                _right.men.Remove(temp_i);

                _light.Trans(_left, temp_i, Man.Empty, _log, LeftMove);

                //移动完成，返回状态树的上一级
                _log.back();
                _right.men.Insert(i, temp_i);
                _left.men.Remove(temp_i);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 查找最短时间过桥方法
        /// </summary>
        public void ShowBest()
        {
            Console.WriteLine("最短时间的过桥方法：");
            _best.ConsoleLog();
        }
        #endregion
    }
}
