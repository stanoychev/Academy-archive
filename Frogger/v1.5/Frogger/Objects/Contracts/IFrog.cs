using Frogger.Objects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IFrog : ISubject
    {
        int Lives { get; set; }
        bool IsAlive { get; set; }
        int FrogLevel { get; set; }
    }
}
