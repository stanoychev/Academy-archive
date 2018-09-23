using GameObjects;
using System;
using System.Threading;
using Utils;

namespace Engine
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IRowCollection rowCollection;

        public ConsoleWriter(IRowCollection rowCollection)
        {
            this.rowCollection = rowCollection;
        }

        public void Execute()
        {
            Console.Clear();
            for (int i = (int)RowID.Row0; i <= (int)RowID.Row15; i++)
            {
                foreach (string item in this.rowCollection.Rows[i].ToString().Split('*'))
                {
                    Console.WriteLine(item);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Thread.Sleep(GlobalConstants.engineClockRatio);
        }
    }
}