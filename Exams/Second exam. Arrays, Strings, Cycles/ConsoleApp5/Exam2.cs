using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int position = int.Parse(Console.ReadLine());
            string[] initialArray = Console.ReadLine().Split(',');
            short[] array = new short[initialArray.GetLength(0)];
            for (int i = 0; i <= initialArray.GetLength(0) - 1; i++)
            {
                array[i] = short.Parse(initialArray[i]);
            } //array allocated

            short steps;
            short size;
            long sum = 0;
            string instructions = Console.ReadLine();
            int forward = 0;
            int backward = 0;
            while (instructions != "exit")
            {
                string[] substring = instructions.Split(' ');
                steps = short.Parse(substring[0]);
                size = short.Parse(substring[2]);
                
                if (instructions.Split(' ')[1] == "forward")
                {
                    for (int i = 1; i <= steps; i++)
                    {
                        position = position + size;
                        while (position > array.GetLength(0) - 1) //position = position % array.GetLength(0);
                        {
                            position = position - array.GetLength(0);
                        }
                        while (position < 0)
                        {
                            position = position + array.GetLength(0);
                        }
                        forward = forward + array[position];
                    }
                }
                else
                {
                    
                    for (int i = 1; i <= steps; i++)
                    {
                        position = position - size;
                        while (position > array.GetLength(0) - 1)
                        {
                            position = position - array.GetLength(0);
                        }
                        while (position < 0)
                        {
                            position = position + array.GetLength(0);
                        }
                        backward = backward + array[position];
                    }
                }
                instructions = Console.ReadLine();
            }
            Console.WriteLine("Forward: {0}", forward);
            Console.WriteLine("Backwards: {0}", backward);
        }
    }
}

