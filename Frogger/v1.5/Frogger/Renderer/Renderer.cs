using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Frogger.Renderer
{
    public static class Renderer
    {
        public static void Execute()
        {
            Console.Clear();
            for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
            {
                foreach (var item in RowCollection.RowCollection.Instance.Rows[i].ToString().Split('*'))
                {
                    Console.WriteLine(item);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Thread.Sleep(GlobalConstants.engineClockRatio);
        }

        public static void LoadGameRows()
        {
            for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
            {
                if (i == (int)RowID.Zero)
                {
                    RowCollection.RowCollection.Instance.Rows[i] = new InfoRow((RowID)i);
                }
                else if (i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                {
                    RowCollection.RowCollection.Instance.Rows[i] =new SafeZoneRow((RowID)i);
                }
                else
                {
                    RowCollection.RowCollection.Instance.Rows[i] =new LaneRow((RowID)i);
                }
            }
        }
    }
}