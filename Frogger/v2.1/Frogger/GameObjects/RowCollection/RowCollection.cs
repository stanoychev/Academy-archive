using Engine;
using System;
using System.Collections.Generic;

namespace GameObjects
{
    public class RowCollection : IRowCollection
    {
        private readonly IDictionary<int, IRow> rows;

        public RowCollection()
        {
            this.rows = new Dictionary<int, IRow>();
        }

        public IDictionary<int, IRow> Rows
        {
            get
            {
                return this.rows;
            }
        }

        public void LoadRows(IFrog frog, IModelFactory modelFactory, ISettings settings)
        {
            Random randomizer = new Random();
            int rows = settings.GameRows - 1;
            for (int RowID = 0; RowID <= rows; RowID++)
            {
                switch (RowID) //this seems retarded, but illustrates the game structure quite well, I think
                {
                    case 0: this.rows.Add(RowID, modelFactory.CreateInfoRow(frog, RowID)); break;
                    case 1: this.rows.Add(RowID, modelFactory.CreateSafeZoneRow(frog, RowID, settings)); break;
                    case 2: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 3: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 4: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 5: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 6: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 7: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 8: this.rows.Add(RowID, modelFactory.CreateSafeZoneRow(frog, RowID, settings)); break;
                    case 9: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 10: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 11: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 12: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 13: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 14: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
              /*1*/ case 15: this.rows.Add(RowID, modelFactory.CreateSafeZoneRow(frog, RowID, settings)); break;
                    case 16: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 17: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 18: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 19: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 20: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
                    case 21: this.rows.Add(RowID, modelFactory.CreateLaneRow(modelFactory.CreateVehicle(randomizer, settings), frog, RowID, settings)); break;
              /*2*/ case 22: this.rows.Add(RowID, modelFactory.CreateSafeZoneRow(frog, RowID, settings)); break;
                }
            }
        }

        public void UnloadRows()
        {
            this.rows.Clear();
        }
    }
}