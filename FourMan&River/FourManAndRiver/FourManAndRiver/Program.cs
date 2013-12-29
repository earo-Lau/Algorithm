using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourManAndRiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.LeftMove();
            client.ShowBest();

            Console.ReadLine();
        }
    }
}
