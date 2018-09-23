using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using Frogger.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Models
{
    public class SafeZoneRow : BaseRow
    {
        public SafeZoneRow(RowID initialRowID) : base(initialRowID)
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
        }
        
        public override string ToString()
        {
            if (base.HasFrog)
            {
                return string.Format("{0}{1}*{0}{2}*{0}{3}",
                    new string(' ', Swamp.Instance.X), //eventualno +/-1
                    Swamp.Instance.ToString().Split('*')[0],
                    Swamp.Instance.ToString().Split('*')[1],
                    Swamp.Instance.ToString().Split('*')[2]);
            }
            else
            {
                return "\n*";
            }
        }
    }
}
