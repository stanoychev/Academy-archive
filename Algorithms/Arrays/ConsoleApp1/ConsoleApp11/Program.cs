﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            foreach (int a in word)
                Console.WriteLine(a-97);
        }
    }
}