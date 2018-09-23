using Frogger.Objects.Models;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Engine.Screens;
using Frogger.Renderer;

namespace Frogger.Updater
{
    public static class Updater
    {
        public static void StartGame()
        {
            while (Swamp.Instance.IsAlive)
            {
                Renderer.Renderer.Execute();
                //ConsoleKeyInfo stamat = Console.ReadKey();
                FroggerMover();

                //понеже има главно две групи редове с колички, режа for цикъла на два for цикъла, така, че да не правя
                //излишни обхождания и проверки, а и за мааалък микро performance boost
                for (int i = (int)RowID.Second; i <= (int)RowID.Seventh; i++)
                {
                    VehicleMover(i);
                }
                for (int i = (int)RowID.Ninth; i <= (int)RowID.Fourteenth; i++)
                {
                    VehicleMover(i);
                }

                CollisionDetector();
                ScoreUpdater();
            }
            Console.Clear();
            Console.WriteLine(GlobalConstants.gameOverFrogger);
            Environment.Exit(0);
        }

        private static void FroggerMover()
        {
            while (Console.KeyAvailable)
            {
                //reading the keys in the tester class, acknowledging the borders of the screen
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow &&
                    Swamp.Instance.Row > 1) //so that it goes no further than the last safe zone
                {
                    Swamp.Instance.Row--;
                }
                else if (key.Key == ConsoleKey.DownArrow &&
                    Swamp.Instance.Row < 15)
                {
                    Swamp.Instance.Row++;
                }
                else if (key.Key == ConsoleKey.LeftArrow &&
                    Swamp.Instance.X > 2)
                {
                    Swamp.Instance.X -= GlobalConstants.frogStepToTheSides;
                }
                else if (key.Key == ConsoleKey.RightArrow &&
                    Swamp.Instance.X < 93)
                {
                    Swamp.Instance.X += GlobalConstants.frogStepToTheSides;
                }
                else if (key.Key == ConsoleKey.OemMinus &&
                        ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed > 0)
                {
                    ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed--;
                }
                else if (key.Key == ConsoleKey.OemPlus &&
                        ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed < 44)
                {
                    ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed++;
                }
            }
        }

        private static void CollisionDetector()
        {
            if ((Swamp.Instance.Row >= (int)RowID.Second && Swamp.Instance.Row <= (int)RowID.Seventh)
                ||
                (Swamp.Instance.Row >= (int)RowID.Ninth && Swamp.Instance.Row <= (int)RowID.Fourteenth))
            {
                int vehicleStart = ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.X;
                int vehicleEnd = ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.X +
                    ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.ToString().Split('*')[0].Length - 1;

                int frogStart = Swamp.Instance.X;
                int frogEnd = Swamp.Instance.X + Swamp.Instance.ToString().Split('*')[0].Length - 1;

                if ((frogStart >= vehicleStart && frogStart <= vehicleEnd) || (frogEnd >= vehicleStart && frogEnd <= vehicleEnd))
                {
                    Swamp.Instance.Lives--;
                    Renderer.Renderer.Execute();
                    ConsoleKeyInfo stamat = Console.ReadKey();
                    ResetFrog();
                }
            }
        }

        private static void ScoreUpdater()
        {
            if (Swamp.Instance.Row == 1)
            {
                Swamp.Instance.Level++;
                ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Score++;
                ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed+=2;
                Renderer.Renderer.Execute();
                ConsoleKeyInfo stamat = Console.ReadKey();
                if (Swamp.Instance.Level == GlobalConstants.maxFrogLevel)
                {
                    Console.Clear();
                    Console.WriteLine(GlobalConstants.wellDoneFrogger);
                    Environment.Exit(0);
                }
                ResetFrog();
            }
        }

        private static void ResetFrog()
        {
            Swamp.Instance.X = GlobalConstants.initialFrogX;
            Swamp.Instance.Row = GlobalConstants.initialFrogRow;
        }

        private static void VehicleMover(int i)
        {
            int gamespeed = ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed;
            int tempSpeed = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.Speed;
            int currentVehiclePosition = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X;

            if (currentVehiclePosition + tempSpeed + gamespeed >= GlobalConstants.screenWidth - 1)
            {
                VehicleSpeedModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                VehicleLengthModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X = 0;
            }
            else
            {
                ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X += tempSpeed + gamespeed;
            }
        }

        private static void VehicleSpeedModifier(LaneRow currentVehicle)
        {
            currentVehicle.VehicleOnTheRow.Speed = RandomNumGenerator(2, 5);
        }

        private static void VehicleLengthModifier(LaneRow currentVehicle)
        {
            currentVehicle.VehicleOnTheRow.VehicleLength = RandomNumGenerator(1, 5);
        }

        private static int RandomNumGenerator(int min, int max)
        {
            Random randNum = new Random();
            return randNum.Next(min, max);
        }
    }
}
/*
 * Upgrades
 * да рефактурирам public static void FroggerMover() от else if на switch
 */


