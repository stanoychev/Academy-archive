using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;


namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = short.Parse(Console.ReadLine());

            string initPoly1 = Console.ReadLine();
            string initPoly2 = Console.ReadLine();

            int[] poly1 = new int[n];
            int[] poly2 = new int[n];

            FillPoly(initPoly1, poly1);
            FillPoly(initPoly2, poly2);

            SumPoly(poly1, poly2); // izsipva vsi4ko v poly1

            PrintPoly(poly1);
        }
        public static void FillPoly (string initPoly, int[] poly)
        {
            string[] substring = initPoly.Split(' ');
            
            for (int i = 0; i <= substring.GetLength(0) - 1; i++)
            {
                    poly[i] = int.Parse(substring[i]);
            }
        }
        public static void SumPoly(int[] poly1, int[] poly2)
        {
            for (int i = 0; i <=poly1.GetLength(0)-1; i++)
            {
                poly1[i] = (int)(poly1[i] + poly2[i]);
            }
        }
        public static void PrintPoly (int[] poly)
        {
            for (int i = 0; i <poly.GetLength(0)-1; i++)
            {
                Console.Write("{0} ",poly[i]);
            }
            Console.Write(poly[poly.GetLength(0)-1]);
        }
    }
}