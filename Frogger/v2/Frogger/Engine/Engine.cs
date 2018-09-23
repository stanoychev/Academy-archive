using GameObjects;
using System;
using System.Linq;
using Utils;

namespace Engine
{
    public class Engine : IEngine
    {
        private readonly IConsoleKeyReader consoleKeyReader;
        private readonly IFrog frog;
        private readonly IConsoleWriter consoleWriter;
        private readonly IRowCollection rowCollection;
        private readonly IModelFactory modelFactory;
        private int gameSpeed;
        private int gameScore;
        private Random randomizer = new Random();
        private bool testConditions;

        public Engine(IConsoleKeyReader consoleKeyReader, IFrog frog, IConsoleWriter consoleWriter, IRowCollection rowCollection, IModelFactory modelFactory)
        {
            this.gameSpeed = GlobalConstants.gameSpeedMin;
            this.gameScore = GlobalConstants.initialGameScore;
            this.consoleKeyReader = consoleKeyReader;
            this.frog = frog;
            this.consoleWriter = consoleWriter;
            this.rowCollection = rowCollection;
            this.modelFactory = modelFactory;
        }
        
        public bool TestConditions
        {
            set
            {
                this.testConditions = value;
            }
        }

        public int GameSpeed //gametesting only
        {
            get
            {
                return this.gameSpeed;
            }
            set
            {
                if (testConditions)
                {
                    if (0 <= value && value <= 3)
                    {
                        this.gameSpeed = value;
                    }
                    testConditions = false;
                }
            }
        }
        
        public int GameScore
        {
            get
            {
                return this.gameScore;
            }
        }
        
        public void Load()
        {
            for (int i = (int)RowID.Row0; i <= (int)RowID.Row15; i++)
            {
                RowID num = (RowID)i;
                switch (num) //this seems retarded, but illustrates the game structure quite well, I think
                {
                    case RowID.Row0: this.rowCollection.Rows.Add(this.modelFactory.CreateInfoRow(num, frog)); break;
                    case RowID.Row1: this.rowCollection.Rows.Add(this.modelFactory.CreateSafeZoneRow(num, frog)); break;
                    case RowID.Row2: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row3: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row4: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row5: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row6: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row7: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row8: this.rowCollection.Rows.Add(this.modelFactory.CreateSafeZoneRow(num, frog)); break;
                    case RowID.Row9: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row10: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row11: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row12: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row13: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row14: this.rowCollection.Rows.Add(this.modelFactory.CreateLaneRow(this.modelFactory.CreateVehicle(this.randomizer), num, frog)); break;
                    case RowID.Row15: this.rowCollection.Rows.Add(this.modelFactory.CreateSafeZoneRow(num, frog)); break;
                }
            }
        }

        public void Run()
        {
            Console.WriteLine(GlobalConstants.welcomeFrogger);//i tova e za vyv renderer-a
            Console.ReadKey();
            
            while (frog.IsAlive)
            {
                consoleWriter.Execute();
                
                //update frog position
                this.consoleKeyReader.UpdateFrogPosition(this.frog);

                //update vehicle position
                for (int i = (int)RowID.Row2; i <= (int)RowID.Row14; i++)
                {
                    if (i != (int)RowID.Row8)
                    {
                        IVehicle vehicle = ((ILaneRow)rowCollection.Rows.ElementAt(i)).VehicleOnTheRow;
                        if (vehicle.X + vehicle.VehicleSpeed + this.gameSpeed
                            >=
                            GlobalConstants.vehicleMaxX)
                        {
                            vehicle.VehicleSpeed = this.randomizer.Next(GlobalConstants.vehicleMinSpeed, GlobalConstants.vehicleMaxSpeed);

                            vehicle.VehicleFillMultiplier = this.randomizer.Next(GlobalConstants.vehicleFillMultiplierMin, GlobalConstants.vehicleFillMultiplierMax);
                            vehicle.X = 0;
                        }
                        else
                        {
                            vehicle.X += vehicle.VehicleSpeed + this.gameSpeed;
                        }
                    }
                }

                //when frog wins
                if (frog.Row == 1)
                {
                    //this can be done more elegantly with an event
                    this.frog.FrogLevel++;
                    this.gameScore++;
                    ((IInfoRow)rowCollection.Rows.ElementAt(0)).GameScore = this.gameScore;
                    this.gameSpeed++;
                    ((IInfoRow)rowCollection.Rows.ElementAt(0)).GameSpeed = this.gameSpeed;
                    {
                        //GlobalMethods.GameFreeze();//toq metod da premestq v renderer-a
                        consoleWriter.Execute();
                        ConsoleKeyInfo enterAnyKey = Console.ReadKey();
                    }
                    if (this.frog.FrogLevel == GlobalConstants.maxFrogLevel)
                    {
                        Console.Clear();
                        Console.WriteLine(GlobalConstants.wellDoneFrogger);
                        Environment.Exit(0);
                    }
                    ResetFrogPosition(this.frog);
                }

                //check for collision
                CheckForCollision(this.frog, this. rowCollection);
            }
            Console.Clear();//i tva e za v renderer-a
            Console.WriteLine(GlobalConstants.gameOverFrogger);
            Environment.Exit(0);
        }

        private void ResetFrogPosition(IFrog frog)
        {
            if (frog.Row > 1 && frog.Row <= GlobalConstants.midLevelFrogRow && frog.FrogLevel >= 2)
            {
                frog.Row = GlobalConstants.midLevelFrogRow;
                frog.X = GlobalConstants.initialFrogX;
            }
            else
            {
                frog.Row = GlobalConstants.initialFrogRow;
                frog.X = GlobalConstants.initialFrogX;
            }
        }

        private void CheckForCollision(IFrog frog, IRowCollection rowcollection) //to refactor it with dictionarri<rowID,Irow>
        {
            //this can be done more elegantly with an event
            if ((frog.Row >= (int)RowID.Row2 && frog.Row <= (int)RowID.Row7)
                ||
                (frog.Row >= (int)RowID.Row9 && frog.Row <= (int)RowID.Row14))
            {
                IVehicle vehicle = ((ILaneRow)rowCollection.Rows.ElementAt(frog.Row)).VehicleOnTheRow;

                if ((frog.X >= vehicle.X && frog.X <= vehicle.VehicleEndX)
                    ||
                    (frog.X + frog.FrogDisplayLength - 1 >= vehicle.X && frog.X + frog.FrogDisplayLength - 1 <= vehicle.VehicleEndX))
                {
                    frog.Lives--;
                    {
                        //GlobalMethods.GameFreeze();//toq metod da premestq v renderer-a
                        consoleWriter.Execute();
                        ConsoleKeyInfo enterAnyKey = Console.ReadKey();
                    }
                    ResetFrogPosition(frog); 
                }
            }
        }
    }
}
