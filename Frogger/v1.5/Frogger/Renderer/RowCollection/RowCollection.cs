using Frogger.Renderer.Contracts;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.RowCollection
{
    public class RowCollection : IRowCollection
    {
        private static readonly RowCollection instance = new RowCollection();

        private RowCollection()
        {
            this.Rows = new IRowID[GlobalConstants.gameRows];
        }

        public IRowID[] Rows
        {
            get;
            private set;
        }

        public static RowCollection Instance
        {
            get
            {
                return instance;
            }
        }
        
    }
}