using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using Frogger.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Utils;

namespace Frogger.Renderer.Models
{
    public class SafeZoneRow : BaseRow
    {
        public SafeZoneRow(RowID initialRowID) : base(initialRowID)
        {
        }
        
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            if (base.HasFrog)
            {
                return string.Format("{0}{1}{4}*{0}{2}{4}*{0}{3}{4}",
                    new string(' ', Frog.Instance.X),
                    Frog.Instance.ToString().Split('*')[0],
                    Frog.Instance.ToString().Split('*')[1],
                    Frog.Instance.ToString().Split('*')[2],
                    new string(' ', GlobalConstants.screenWidth - 1 - Frog.Instance.X - Frog.Instance.FrogDisplayLength));
            }
            else
            {
                //return "\n*";
                return string.Format("{0}*{0}*{0}", new string(' ', GlobalConstants.screenWidth-1));
            }
        }
    }
}
