using Engine;
using System.Collections.Generic;

namespace GameObjects
{
    public interface IRowCollection
    {
        IDictionary<int, IRow> Rows { get; }
        void LoadRows(IFrog frog, IModelFactory modelFactory, ISettings settings);
        void UnloadRows();
    }
}
