using Engine;
using System.Collections.Generic;
using Utils;

namespace GameObjects
{
    public class RowCollection : IRowCollection
    {
        private readonly IList<IRow> rows;
        
        public RowCollection()
        {
            this.rows = new List<IRow>();
        }

        public IList<IRow> Rows
        {
            get
            {
                return this.rows;
            }
        }
    }
}