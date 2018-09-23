using System;

namespace GameObjects
{
    public abstract class BaseRow : IRow
    {
        private readonly RowID rowID;
        private readonly IFrog frog;

        public BaseRow(RowID rowID, IFrog frog)
        {
            if (rowID < RowID.Row0 || rowID > RowID.Row15)
            {
                throw new ArgumentException("Invalid Row identification number, must be between 0 and 15 (for now).");
            }
            this.rowID = rowID;
            this.frog = frog;
        }
        
        protected IFrog Frog
        {
            get
            {
                return this.frog;
            }
        }

        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }
    }
}
