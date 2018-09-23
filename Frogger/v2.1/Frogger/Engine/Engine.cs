using GameObjects;
using System;

namespace Engine
{
    public class Engine : IEngine
    {
        private readonly IFrog frog;
        private readonly IConsoleWriter consoleWriter;
        private readonly IRowCollection rowCollection;
        private readonly ISettings settings;
        private Random randomizer = new Random();

        public Engine(IFrog frog, IConsoleWriter consoleWriter, IRowCollection rowCollection, ISettings settings)
        {
            this.settings = settings;
            this.frog = frog;
            this.consoleWriter = consoleWriter;
            this.rowCollection = rowCollection;
        }
        
        public void Run(IModelFactory modelFactory, IConsoleReader consoleReader)
        {
            while (true)
            {

                this.consoleWriter.WellcomeFrogger();
                this.consoleWriter.SelectGameSettings(consoleReader);
                this.consoleWriter.SetWindowDimentions();
                this.rowCollection.LoadRows(this.frog, modelFactory, this.settings);
                frog.Row = settings.InitialFrogRow;
                frog.X = settings.InitialFrogX;

                while (this.frog.IsAlive)
                {
                    consoleWriter.Render();
                    
                    consoleReader.UpdateFrogPosition(this.frog, this.settings);
                    
                    UpdateVehiclesPositions();
                    
                    CheckIfFrogWins();
                    
                    CheckForCollision();
                }
                consoleWriter.ExitFrogger(this.settings.GameOverFrogger);
                this.rowCollection.UnloadRows();
            }
        }

        private void UpdateVehiclesPositions()
        {
            foreach (int RowID in this.settings.LaneRowIndexes)
            {
                IVehicle vehicle = ((ILaneRow)rowCollection.Rows[RowID]).VehicleOnTheRow;

                if (vehicle.X + vehicle.VehicleSpeed + this.settings.GameSpeed
                    >=
                    this.settings.VehicleMaxX(vehicle.VehicleDisplayLength))
                {
                    vehicle.VehicleSpeed = this.randomizer.Next(this.settings.VehicleMinSpeed, this.settings.VehicleMaxSpeed);
                    vehicle.VehicleFillMultiplier = this.randomizer.Next(this.settings.VehicleFillMultiplierMin, this.settings.VehicleFillMultiplierMax);
                    vehicle.X = 0;
                }
                else
                {
                    vehicle.X += vehicle.VehicleSpeed + this.settings.GameSpeed;
                }
            }
        }

        private void CheckIfFrogWins()
        {
            if (frog.Row == 1)
            {
                //this can be done more elegantly with an event
                this.frog.FrogLevel++;
                this.settings.EngineDemand = true;
                this.settings.GameScore++;
                ((IInfoRow)rowCollection.Rows[0]).GameScore = this.settings.GameScore;
                this.settings.EngineDemand = true;
                this.settings.GameSpeed++;
                ((IInfoRow)rowCollection.Rows[0]).GameSpeed = this.settings.GameSpeed;
                this.consoleWriter.GameFreeze();
                if (this.frog.FrogLevel == this.settings.MaxFrogLevel)
                {
                    consoleWriter.ExitFrogger(this.settings.WellDoneFrogger);
                }
                ResetFrogPosition();
            }
        }

        private void ResetFrogPosition()
        {
            this.frog.Row = this.settings.InitialFrogRow;
            this.frog.X = this.settings.InitialFrogX;
        }

        private void CheckForCollision()
        {
            //possibly this can be done more elegantly with an event
            bool checkActivator = true;
            foreach (int safeRowIndex in this.settings.SafeRowIndexes)
            {
                if (this.frog.Row==safeRowIndex)
                {
                    checkActivator = false;
                    break;
                }
            }
            if (checkActivator)
            {
                IVehicle vehicle = ((ILaneRow)rowCollection.Rows[this.frog.Row]).VehicleOnTheRow;

                if ((this.frog.X >= vehicle.X && this.frog.X <= vehicle.VehicleEndX)
                    ||
                    (this.frog.X + frog.FrogDisplayLength - 1 >= vehicle.X && this.frog.X + this.frog.FrogDisplayLength - 1 <= vehicle.VehicleEndX))
                {
                    this.frog.Lives--;
                    this.consoleWriter.GameFreeze();
                    ResetFrogPosition();
                }
            }
        }
    }
}
