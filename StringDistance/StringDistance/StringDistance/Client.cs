using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringDistance
{
    public class Client
    {
        Model best;
        Model leftRound;
        Model rightRound;

        string str;
        char c1;
        char c2;

        System.Diagnostics.Stopwatch sw;

        public Client()
        {
            best = new Model() { c1 = -1, c2 = -1 };
            leftRound = new Model() { c1 = -1, c2 = -1 };
            rightRound = new Model() { c1 = -1, c2 = -1 };

            sw = new System.Diagnostics.Stopwatch();
        }

        public void SearchString(string str, char c1, char c2)
        {
            this.str = str;
            this.c1 = c1;
            this.c2 = c2;

            int count = str.Count();
            Console.WriteLine("开始搜寻字符串{0}中{1}到{2}的最短距离...", str, c1, c2);

            sw.Start();
            for (int i = 0; i < (count / 2); i++)
            {
                LeftRount(str[i], i);
                RightRount(str[count - 1 - i], count - 1 - i);
            }
            if (leftRound.c1 != -1 && rightRound.c2 != -1)
            {
                CompareBest(new Model() { c1 = leftRound.c1, c2 = rightRound.c2 });
            }
            sw.Stop();

            ConsoleResult();
        }

        public void LeftRount(char cmp, int index)
        {
            if (cmp == c1)
            {
                leftRound.c1 = index;
            }
            else if (leftRound.c1 != -1 && cmp == c2)
            {
                leftRound.c2 = index;
                CompareBest(leftRound);
                leftRound.c2 = -1;
            }
        }

        public void RightRount(char cmp, int index)
        {
            if (cmp == c2)
            {
                rightRound.c2 = index;
            }
            else if (rightRound.c2 != -1 && cmp == c1)
            {
                rightRound.c1 = index;
                CompareBest(rightRound);
                rightRound.c1 = -1;
            }
        }

        public void CompareBest(Model model)
        {
            if ((best.c1 == -1 && best.c2 == -1) || model.distance < best.distance)
            {
                best.c1 = model.c1;
                best.c2 = model.c2;
            }
        }

        public void ConsoleResult()
        {
            Console.WriteLine("搜寻结果:");
            if (best.c1 != -1 && best.c2 != -1)
            {
                Console.WriteLine("最短距离从{0}到{1}。共{2}个字符", best.c1, best.c2, best.distance);
            }
            Console.WriteLine("抱歉，没有找到相关字符段!!");
            Console.WriteLine("共用时{0}", sw.Elapsed);
        }
    }
}
