using System.Collections.Generic;

namespace GameObjects
{
    public interface IRowCollection
    {
        IList<IRow> Rows { get; }
    }
}
