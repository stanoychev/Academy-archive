using Frogger.Objects.Models;
using Frogger.Renderer;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Linq;

namespace Frogger.Engine
{
    public static class Engine
    {
        public static void Run()
        {
            Renderer.Renderer.LoadGameRows();
            
            Console.SetWindowSize(GlobalConstants.screenWidth, GlobalConstants.screenHeight);
            Console.SetBufferSize(GlobalConstants.screenWidth, GlobalConstants.screenHeight);

            Frog.Instance.IsAlive = true;

            Console.WriteLine(GlobalConstants.welcomeFrogger);
            Console.ReadKey();
            
            while (Frog.Instance.IsAlive)
            {
                Renderer.Renderer.Execute();

                Frog.Instance.UpdateFrogPosition();

                for (int i = (int)RowID.Second; i <= (int)RowID.Seventh; i++)
                {
                    ((Vehicle)((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow).UpdateVehiclePosition();
                }
                for (int i = (int)RowID.Ninth; i <= (int)RowID.Fourteenth; i++)
                {
                    ((Vehicle)((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow).UpdateVehiclePosition();
                }

                Frog.Instance.CheckForCollision();
            }
            Console.Clear();
            Console.WriteLine(GlobalConstants.gameOverFrogger);
            Environment.Exit(0);
        }
    }
}
