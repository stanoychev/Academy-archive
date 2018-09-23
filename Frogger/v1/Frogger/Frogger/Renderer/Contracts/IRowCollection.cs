using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Contracts
{
    public interface IRowCollection
    {
        //IRowID[] Rows { get; }
        ICollection<IRowID> Rows { get; }
    }
}
