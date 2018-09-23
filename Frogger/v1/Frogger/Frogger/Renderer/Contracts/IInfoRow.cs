using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Renderer.Enums;

namespace Frogger.Renderer.Contracts
{
    public interface IInfoRow: IRowID
    {
        int Speed { get; set; }
        int Lives { get; }
        int Score { get; set; }
    }
}
