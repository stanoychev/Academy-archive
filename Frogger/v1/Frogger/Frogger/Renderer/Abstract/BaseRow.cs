using Frogger.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Renderer.Enums;
using Frogger.Objects.Models;

namespace Frogger.Renderer.Abstract
{
    public abstract class BaseRow : IRow
    {
        //tuka ima property bool HasFrog;
        private readonly RowID rowID;
        //при инициализирането на обектите в колекцията им се слага rowID и повече не се бара.

        public BaseRow(RowID initialRowID)
        {
            this.rowID = initialRowID;
        }

        //public BaseRow(int frogX, bool hasFrog)
        //{
        //    this.FrogX = frogX;
        //    this.HasFrog = hasFrog;
        //}

        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }

        public bool HasFrog
        {
            get
            {
                if ((int)RowID == Objects.Models.Swamp.Instance.Row)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
