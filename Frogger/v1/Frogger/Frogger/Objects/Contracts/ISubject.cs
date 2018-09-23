using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Contracts
{
    public interface ISubject
    {
        int X { get; set; }
        int Row { get; set; }
    } //тези две пропъртита, понеже са общи за жабата и колата ги изнесох в базов интерфейс
    
}
