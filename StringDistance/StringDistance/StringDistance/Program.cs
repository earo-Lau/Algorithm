using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.SearchString("asfdqjqejsadfewrjsksfdsaflkkdalkdsad", 'j', 'd');

            Console.ReadLine();
        }
    }
}
